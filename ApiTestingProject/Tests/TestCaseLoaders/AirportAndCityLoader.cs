using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ApiTestingProject
{
    public static class AirportAndCityLoader
    {
        private static int m_resultCount;

        public static LocationType LocationType { get; private set; }
        public static string Keyword { get; private set; }
        public static int ExpectedNumberOfResults { get; private set; }

        public static object[] SubTypeCases { get; private set; }
        public static object[] NameCases { get; private set; }
        public static object[] DetailedNameCases { get; private set; }
        public static object[] IdCases { get; private set; }
        public static object[] TimeZoneOffsetCases { get; private set; }
        public static object[] IataCodeCases { get; private set; }
        public static object[] GeoCodeCases { get; private set; }
        public static object[] CityCases { get; private set; }
        public static object[] CountryCases { get; private set; }
        public static object[] RegionCases { get; private set; }

        static AirportAndCityLoader()
        {
            string execDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Application xlApp = new Application();

            Workbook xlWorkbook = xlApp.Workbooks.Open(Path.Combine(execDirectory, @"..\..\AirportAndCityTestCases.xlsx"));

            Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            Range xlRange = xlWorksheet.Cells;

            //Load cases from excel sheet
            LoadCases(xlRange);

            //Dispose of resources
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private static void LoadCases(Range xlRange)
        {
            //Get result count
            int resultCount = 0;
            int rowIndex = 4;

            while ((xlRange.Cells[rowIndex, 4] as Range).Value2 != null)
            {
                ++resultCount;
                ++rowIndex;
            }

            m_resultCount = resultCount;

            //Get LocationType
            string locationTypeRaw = (xlRange.Cells[1, 2] as Range).Value2;

            LocationType = (LocationType)Enum.Parse(typeof(LocationType), locationTypeRaw);

            //Get Keyword
            Keyword = (xlRange.Cells[2, 2] as Range).Value2;

            //Get expected number of results
            ExpectedNumberOfResults = (int)(xlRange.Cells[3, 2] as Range).Value2;

            SubTypeCases = new object[m_resultCount];
            NameCases = new object[m_resultCount];
            DetailedNameCases = new object[m_resultCount];
            IdCases = new object[m_resultCount];
            TimeZoneOffsetCases = new object[m_resultCount];
            IataCodeCases = new object[m_resultCount];
            GeoCodeCases = new object[m_resultCount];
            CityCases = new object[m_resultCount];
            CountryCases = new object[m_resultCount];
            RegionCases = new object[m_resultCount];

            const int baseRowIndex = 4;

            for (int i = 0; i < m_resultCount; ++i)
            {
                //Get SubType Case
                LocationType subType = (LocationType)Enum.Parse(typeof(LocationType), (xlRange.Cells[baseRowIndex + i, 5] as Range).Value2);
                SubTypeCases[i] = new object[] { i, subType };

                //Get Name Case
                string name = (xlRange.Cells[baseRowIndex + i, 6] as Range).Value2;
                NameCases[i] = new object[] { i, name };

                //Get DetailedName Case
                string detailedName = (xlRange.Cells[baseRowIndex + i, 7] as Range).Value2;
                DetailedNameCases[i] = new object[] { i, detailedName };

                //Get Id Case
                string id = (xlRange.Cells[baseRowIndex + i, 8] as Range).Value2;
                IdCases[i] = new object[] { i, id };

                //Get TimeZoneOffset Case
                TimeSpan timeZoneOffset = TimeSpan.Parse((xlRange.Cells[baseRowIndex + i, 9] as Range).Value2.ToString());
                TimeZoneOffsetCases[i] = new object[] { i, timeZoneOffset };

                //Get IataCode Case
                string iataCode = (xlRange.Cells[baseRowIndex + i, 10] as Range).Value2;
                IataCodeCases[i] = new object[] { i, iataCode };

                //Get GeoCode Case
                float latitude = (float)(xlRange.Cells[baseRowIndex + i, 11] as Range).Value2;
                float longitude = (float)(xlRange.Cells[baseRowIndex + i, 12] as Range).Value2;
                GeoCodeCases[i] = new object[] { i, latitude, longitude };

                //Get City Case
                string cityName = (xlRange.Cells[baseRowIndex + i, 13] as Range).Value2;
                string cityCode = (xlRange.Cells[baseRowIndex + i, 14] as Range).Value2;
                CityCases[i] = new object[] { i, cityName, cityCode };

                //Get Country Case
                string countryName = (xlRange.Cells[baseRowIndex + i, 15] as Range).Value2;
                string countryCode = (xlRange.Cells[baseRowIndex + i, 16] as Range).Value2;
                CountryCases[i] = new object[] { i, countryName, countryCode };

                //Get Region Case
                string regionCode = (xlRange.Cells[baseRowIndex + i, 17] as Range).Value2;
                RegionCases[i] = new object[] { i, regionCode };
            }
        }
    }
}
