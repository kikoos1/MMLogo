using System;
using System.Collections.Generic;
namespace MM
{
    class MMLogo
    {
        static List<List<string>> board;
        class Logo
        {
            
            private int width;
           private string emptyText = "-";//С какъв char , ще запълваме празното пространство
            private string fillText = "*";// С какъв char , ще изчертаваме M в конзолата
           
            public void setWidth(int width)
            {
                this.width = width;
            }
           
            private  void showLogo()
            {
                var sb = new System.Text.StringBuilder();

                foreach (List<string> row in board)
                    sb.AppendLine(string.Join("", row.ToArray()));



                Console.Write(sb.ToString());
            }
          
            public void createLogo()
            {

                board = new List<List<string>>();
              
               
               
                for (int row = 0; row <= this.width; row++)//Разделяме M на 4 линии
                {
                    Func<int, int, bool> p1 = (row, col) => { // Функцията приема int, int и връща bool
                        int startX = this.width - 1 - row;
                        return (col > startX && col <= (startX + this.width));
                    };
                    Func<int, int, bool> p2 = (row, col) => {
                        int startX = this.width - 1 + row;
                        return (col > startX && col <= (startX + this.width));
                    };
                    Func<int, int, bool> p3 = (row, col) => {
                        int startX = (3 * this.width) - 1 - row;
                        return (col > startX && col <= (startX + this.width));
                    };
                    Func<int, int, bool> p4 = (row, col) => {
                        int startX = (3 * this.width) - 1 + row;
                        return (col > startX && col <= (startX + this.width));
                    };
                    var rowChars = new List<string>();
                    for (int i = 0; i < 2; i++)
                    {
                       
                        for (int col = 0; col < (this.width * 5); col++)
                            rowChars.Add((p1(row, col) || p2(row, col) || p3(row, col) || p4(row, col)) ? fillText : emptyText);
                        board.Add(rowChars);
                    }
                }
                this.showLogo();

              }
           
        }
       

       

        public static void Main()
        {
            Console.WriteLine("Enter the width of the logo: ");

            var width = ReadWidth();// Прочитаме дължината на логото
            Logo MM = new Logo();
            MM.setWidth(width);
            MM.createLogo();


        }
        public static int ReadWidth()
        {
            Console.WriteLine("Enter Width (odd number beteween 2< Input < 1000): ");
            var widthString = Console.ReadLine();
            int width = 0;
            if (!int.TryParse(widthString, out width) || width < 2 || width > 1000 || width %2 == 0)
            {
                Console.WriteLine("The value entered is not accepted, please try again.");
                ReadWidth();
            }
            return width;
        }
      
    }
}
