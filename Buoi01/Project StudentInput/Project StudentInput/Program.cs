namespace Project_StudentInput_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==== THÔNG TIN SINH VIÊN ===="); 
            Console.Write("Nhập họ Tên: ");
            string fullName = Console.ReadLine();
            Console.Write("Nhập MSSV: ");
            string MSSV = Console.ReadLine();
            Console.Write("Nhập lớp: ");
            string Lop = Console.ReadLine();

        }
    }
}
