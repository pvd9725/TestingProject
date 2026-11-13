using Calculator_17_Dieu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace CalculationTest_17_Dieu
{
    [TestClass]
    public class UnitTest_17_Dieu
    {
        public TestContext TestContext_17_Dieu { get; set; }

        [TestMethod]
        // TC1: a = 1, b = -5 , c = 4 -> nghiệm kép, số nghiệm = 2
        public void TC1_Test_HaiNghiemPhanBiet_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -5, 4);
            Assert.AreEqual(2, pt_17_Dieu.GetSoNghiem_17_Dieu());
        }
        [TestMethod]
        // TC2: a = 1, b = -5 , c = 4 -> x1 = 4
        public void TC2_Test_KiemTraX1_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -5, 4);
            Assert.AreEqual(4.0, pt_17_Dieu.GetX1_17_Dieu(), 0.0001);
        }
        [TestMethod]
        // TC3: a = 1, b = -5 , c = 4 -> x2 = 1
        public void TC3_Test_KiemTraX2_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -5, 4);
            Assert.AreEqual(1.0, pt_17_Dieu.GetX2_17_Dieu(), 0.0001);
        }
        [TestMethod]
        // TC4: a = 1, b = -5 , c= 4 -> delta = 9
        public void TC4_Test_KiemTraDelta_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -5, 4);
            Assert.AreEqual(9.0, pt_17_Dieu.GetDelta_17_Dieu(), 0.0001);
        }
        private QuadraticEquation_17_Dieu pt_17_Dieu;
        [TestMethod]
        // TC5: a = 1, b = -2 , c= 1 -> nghiệm kép, số nghiệm = 1
        public void TC5_Test_NghiemKep_SoNghiem_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -2, 1);
            Assert.AreEqual(1, pt_17_Dieu.GetSoNghiem_17_Dieu());
        }

        [TestMethod]
        // TC6: a = 1, b = -2 , c= 1 -> x1 = x2 = 1
        public void TC6_Test_NghiemKep_GiaTriX1_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -2, 1);
            Assert.AreEqual(1.0, pt_17_Dieu.GetX1_17_Dieu(), 0.0001);
        }

        [TestMethod]
        // TC7: a = 1, b = -2 , c= 1 -> delta = 0
        public void TC7_Test_NghiemKep_Delta_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, -2, 1);
            Assert.AreEqual(0.0, pt_17_Dieu.GetDelta_17_Dieu(), 0.0001);
        }
        [TestMethod]
        // TC8: a=1, b=1, c=1 → vô nghiệm, số nghiệm = 0
        public void TC8_Test_VoNghiem_SoNghiem_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, 1, 1);
            Assert.AreEqual(0, pt_17_Dieu.GetSoNghiem_17_Dieu());
        }
        [TestMethod]
        // TC9: a=1, b=1, c=1 → delta = -3
        public void TC9_Test_VoNghiem_Delta_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, 1, 1);
            Assert.AreEqual(-3, pt_17_Dieu.GetDelta_17_Dieu());
        }
        [TestMethod]
        // TC10: a=1, b=1, c=1 → GetX1 phải ném exception
        [ExpectedException(typeof(InvalidOperationException))]
        public void TC10_Test_VoNghiem_GetX1_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, 1, 1);
            pt_17_Dieu.GetX1_17_Dieu();
        }
        [TestMethod]
        // TC11: a = 0 -> ném ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TC11_HeSoA_Bang0_NemException_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(0, 2, 1);
            pt_17_Dieu.GetSoNghiem_17_Dieu();
        }
        [TestMethod]
        //TC12: a = 2, b=0, c=-8 -> x1=2, x2 = -2
        public void TC12_HeSoB_Bang0_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(2, 0, -8);
            Assert.AreEqual(2, pt_17_Dieu.GetSoNghiem_17_Dieu());
            Assert.AreEqual(2.0, pt_17_Dieu.GetX1_17_Dieu(), 0.0001);
            Assert.AreEqual(-2.0, pt_17_Dieu.GetX2_17_Dieu(), 0.0001);
        }
        [TestMethod]
        //TC13: a = 1, b=0, c=0 -> nghiệm kép x = 0
        public void TC13_HeSoB_Va_C_Bang0_17_Dieu()
        {
            pt_17_Dieu = new QuadraticEquation_17_Dieu(1, 0, 0);
            Assert.AreEqual(1, pt_17_Dieu.GetSoNghiem_17_Dieu());
            Assert.AreEqual(0.0, pt_17_Dieu.GetX1_17_Dieu(), 0.0001);
        }
        public static IEnumerable<object[]> GetTestDataFromCSV_17_Dieu()
        {
            string filePath_17_Dieu = "TestData_17_Dieu.csv";

            var lines_17_Dieu = File.ReadAllLines(filePath_17_Dieu).Skip(1);

            foreach (var line_17_Dieu in lines_17_Dieu)
            {
                if (string.IsNullOrWhiteSpace(line_17_Dieu)) continue;

                var cols_17_Dieu = line_17_Dieu.Split(',');

                yield return new object[] {
                    double.Parse(cols_17_Dieu[0]),
                    double.Parse(cols_17_Dieu[1]),
                    double.Parse(cols_17_Dieu[2]),
                    double.Parse(cols_17_Dieu[3])
                };
            }
        }
        [TestMethod]
        [DynamicData(nameof(GetTestDataFromCSV_17_Dieu), DynamicDataSourceType.Method)]
        public void TC14_Delta_DynamicData_17_Dieu(double a_17_Dieu, double b_17_Dieu, double c_17_Dieu, double expectedDelta_17_Dieu)
        {
            TestContext_17_Dieu?.WriteLine($"Testing with: a={a_17_Dieu}, b={b_17_Dieu}, c={c_17_Dieu}, Expected Delta={expectedDelta_17_Dieu}");

            var equation_17_Dieu = new QuadraticEquation_17_Dieu(a_17_Dieu, b_17_Dieu, c_17_Dieu);
            double actualDelta_17_Dieu = equation_17_Dieu.GetDelta_17_Dieu();
            Assert.AreEqual(expectedDelta_17_Dieu, actualDelta_17_Dieu, 0.0001,
                $"Kết quả Delta không khớp cho bộ dữ liệu: a={a_17_Dieu}, b={b_17_Dieu}, c={c_17_Dieu}");
        }
    }
    [TestClass]
    public class ExcelTest_17_Dieu
    {
        public TestContext TestContext_17_Dieu { get; set; }
        public static IEnumerable<object[]> GetExcelTestData_ClosedXML_17_Dieu()
        {
            string path_17_Dieu = Path.Combine(Directory.GetCurrentDirectory(), "excel_data_17_Dieu.xlsx");

            using (var workbook_17_Dieu = new XLWorkbook(path_17_Dieu))
            {
                var worksheet_17_Dieu = workbook_17_Dieu.Worksheet(1);

                var rows_17_Dieu = worksheet_17_Dieu.RangeUsed().RowsUsed().Skip(1);

                foreach (var row_17_Dieu in rows_17_Dieu)
                {
                    yield return new object[] {
                        row_17_Dieu.Cell(1).IsEmpty() ? 0 : row_17_Dieu.Cell(1).GetValue<double>(),
                        row_17_Dieu.Cell(2).IsEmpty() ? 0 : row_17_Dieu.Cell(2).GetValue<double>(),
                        row_17_Dieu.Cell(3).IsEmpty() ? 0 : row_17_Dieu.Cell(3).GetValue<double>(),
                        row_17_Dieu.Cell(4).IsEmpty() ? 0 : row_17_Dieu.Cell(4).GetValue<double>(),
                    };
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetExcelTestData_ClosedXML_17_Dieu), DynamicDataSourceType.Method)]
        public void TC15_CheckDelta_Excel_ClosedXML_17_Dieu(double a_17_Dieu, double b_17_Dieu, double c_17_Dieu, double expectedDelta_17_Dieu)
        {

            TestContext_17_Dieu?.WriteLine($"Testing: (a={a_17_Dieu}, b={b_17_Dieu}, c={c_17_Dieu})");
            var pt_17_Dieu = new QuadraticEquation_17_Dieu(a_17_Dieu, b_17_Dieu, c_17_Dieu);

            double actualDelta_17_Dieu = pt_17_Dieu.GetDelta_17_Dieu();

            Assert.AreEqual(expectedDelta_17_Dieu, actualDelta_17_Dieu, 0.0001);
        }
    }
}