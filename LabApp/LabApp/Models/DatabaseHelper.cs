using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LabApp.Models
{
    public class DatabaseHelper : IDisposable
    {
        private SQLiteConnection db { get; set; }

        public DatabaseHelper()
        {
        }
        public SQLiteConnection initDb()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "airquality.db");
            db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);

            /* db.DeleteAll<InstallationEntity>();
             db.DeleteAll<MeasurementEntity>();
             db.DeleteAll<MeasurementItemEntity>();
             db.DeleteAll<MeasurementValue>();
             db.DeleteAll<AirQualityIndex>();
             db.DeleteAll<AirQualityStandard>();*/


            db.CreateTable<InstallationEntity>();
            db.CreateTable<MeasurementEntity>();
            db.CreateTable<MeasurementItemEntity>();
            db.CreateTable<MeasurementValue>();
            db.CreateTable<AirQualityIndex>();
            db.CreateTable<AirQualityStandard>();


            return db;
        }
        public static void saveInstallation(List<Installation> installations)
        {

            App.db.RunInTransaction(() => {

                App.db.DeleteAll<InstallationEntity>();
                foreach (Installation installation in installations)
                {
                    App.db.Insert(new InstallationEntity(installation));
                }
            });

        }
        public static void saveMeasurement(List<Measurement> measurements)
        {
            App.db.RunInTransaction(() => {
                App.db.DeleteAll<MeasurementEntity>();
                App.db.DeleteAll<MeasurementItemEntity>();
                App.db.DeleteAll<MeasurementValue>();
                App.db.DeleteAll<AirQualityIndex>();
                App.db.DeleteAll<AirQualityStandard>();

                foreach (Measurement measurement in measurements)
                {
                    App.db.InsertAll(measurement.Current.Values, false);
                    App.db.InsertAll(measurement.Current.Indexes, false);
                    App.db.InsertAll(measurement.Current.Standards, false);

                    MeasurementItemEntity current = new MeasurementItemEntity(measurement.Current);
                    App.db.Insert(current);

                    MeasurementEntity newMeasuremetn = new MeasurementEntity(measurement, current);
                    App.db.Insert(newMeasuremetn);

                }
            });
        }

        public static List<Installation> getInstallation()
        {
            List<InstallationEntity> installationsEntity = App.db.Table<InstallationEntity>().ToList();

            List<Installation> installations = new List<Installation>();
            foreach (InstallationEntity item in installationsEntity)
            {
                installations.Add(new Installation(item));
            }

            return installations;
        }

        public static List<Measurement> getMeasurements()
        {
            List<MeasurementEntity> measurementEntities = App.db.Table<MeasurementEntity>().ToList();
            List<Measurement> measurements = new List<Measurement>();

            foreach (MeasurementEntity item in measurementEntities)
            {

                InstallationEntity installationEntity = App.db.Get<InstallationEntity>(item.InstallationId);
                Installation installation = new Installation(installationEntity);

                MeasurementItemEntity measurementItemEntity = App.db.Get<MeasurementItemEntity>(item.CurrentId);

                var valuesArray = JArray.Parse(measurementItemEntity.Values);
                var indexesArray = JArray.Parse(measurementItemEntity.Indexes);
                var standardsArray = JArray.Parse(measurementItemEntity.Standards);


                var valueIDs = parseToIntArray(valuesArray, "Id");
                var indexIDs = parseToIntArray(indexesArray, "Id");
                var standardIDs = parseToIntArray(standardsArray, "Id");

                var measurementValues = App.db.Table<MeasurementValue>().Where(x => valueIDs.Contains(x.Id)).ToArray();
                var measurementIndexes = App.db.Table<AirQualityIndex>().Where(x => indexIDs.Contains(x.Id)).ToArray();
                var measurementStandards = App.db.Table<AirQualityStandard>().Where(x => standardIDs.Contains(x.Id)).ToArray();


                MeasurementItem measurementItem = new MeasurementItem(measurementItemEntity, measurementValues, measurementIndexes, measurementStandards);

                Measurement measurement = new Measurement(item, installation, measurementItem);
                measurements.Add(measurement);
            }


            return measurements;
        }
        public static int[] parseToIntArray(JArray values, string key)
        {
            JObject JObject;
            int[] arr = new int[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                JObject = JObject.Parse(values[i].ToString());
                arr[i] = (int)JObject[key];
            }
            return arr;
        }

        public void Dispose()
        {
            db?.Dispose();
            db = null;
        }
    }
}
