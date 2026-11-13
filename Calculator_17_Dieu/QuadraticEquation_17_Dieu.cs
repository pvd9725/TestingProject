using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_17_Dieu
{
    public class QuadraticEquation_17_Dieu
    {
            private double a_17_Dieu, b_17_Dieu, c_17_Dieu;

            public QuadraticEquation_17_Dieu(double a_17_Dieu, double b_17_Dieu, double c_17_Dieu)
            {
                this.a_17_Dieu = a_17_Dieu;
                this.b_17_Dieu = b_17_Dieu;
                this.c_17_Dieu = c_17_Dieu;
            }
            //tính delta_17_Dieu
            public double GetDelta_17_Dieu()
            {
                return b_17_Dieu * b_17_Dieu - 4 * a_17_Dieu * c_17_Dieu;
            }
            // Trả về số nghiệm: 0, 1, hoặc 2
            public int GetSoNghiem_17_Dieu()
            {
                if (a_17_Dieu == 0)
                    throw new ArgumentException("Hệ số a phải khác 0");

                double delta_17_Dieu = GetDelta_17_Dieu();
                if (delta_17_Dieu < 0) return 0;
                if (delta_17_Dieu == 0) return 1;
                return 2;
            }
            // Nghiệm x1 (delta_17_Dieu >= 0)
            public double GetX1_17_Dieu()
            {
                double delta_17_Dieu = GetDelta_17_Dieu();
                if (delta_17_Dieu < 0)
                    throw new InvalidOperationException("Phương trình vô nghiệm thực");
                return (-b_17_Dieu + Math.Sqrt(delta_17_Dieu)) / (2 * a_17_Dieu);
            }
            // Nghiệm x2 (delta_17_Dieu > 0)
            public double GetX2_17_Dieu()
            {
                double delta_17_Dieu = GetDelta_17_Dieu();
                if (delta_17_Dieu < 0)
                    throw new InvalidOperationException("Phương trình vô nghiệm thực");
                return (-b_17_Dieu - Math.Sqrt(delta_17_Dieu)) / (2 * a_17_Dieu);
            }
            // Trả về chuỗi kết quả 
            public string Solve_17_Dieu()
            {
                if (a_17_Dieu == 0)
                    return "Hệ số a phải khác 0!";

                double delta_17_Dieu = GetDelta_17_Dieu();
                string kq_17_Dieu = $"Phương trình: {a_17_Dieu}x² + {b_17_Dieu}x + {c_17_Dieu} = 0\r\n";
                kq_17_Dieu += $"Δ = {delta_17_Dieu}\r\n";

                if (delta_17_Dieu > 0)
                {
                    kq_17_Dieu += $"Δ > 0 → Hai nghiệm phân biệt:\r\n";
                    kq_17_Dieu += $"  x1 = {Math.Round(GetX1_17_Dieu(), 6)}\r\n";
                    kq_17_Dieu += $"  x2 = {Math.Round(GetX2_17_Dieu(), 6)}";
                }
                else if (delta_17_Dieu == 0)
                {
                    kq_17_Dieu += $"Δ = 0 → Nghiệm kép:\r\n";
                    kq_17_Dieu += $"  x1 = x2 = {Math.Round(GetX1_17_Dieu(), 6)}";
                }
                else
                {
                    kq_17_Dieu += "Δ < 0 → Phương trình vô nghiệm thực.";
                }

                return kq_17_Dieu;

            }
        }
    }