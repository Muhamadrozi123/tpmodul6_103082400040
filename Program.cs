using System;
using System.Collections.Generic;
using System.Text;

namespace tpmodul6_103082400040
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        // Konstruktor - menerima judul video
        public SayaTubeVideo(string title)
        {
            // PRECONDITION: Judul tidak null dan maksimal 100 karakter
            if (title == null)
            {
                throw new ArgumentNullException("title", "Judul video tidak boleh null");
            }

            if (title.Length > 100)
            {
                throw new ArgumentException("Judul video maksimal 100 karakter");
            }

            // Generate random 5-digit ID
            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        // Method untuk menambah play count
        public void IncreasePlayCount(int increment)
        {
            // PRECONDITION: Input maksimal 10.000.000 per panggilan
            if (increment > 10000000)
            {
                throw new ArgumentException("Penambahan play count maksimal 10.000.000 per panggilan");
            }

            if (increment < 0)
            {
                throw new ArgumentException("Penambahan play count tidak boleh negatif");
            }

            // EXCEPTION: Cek overflow dengan checked keyword
            try
            {
                checked
                {
                    this.playCount = this.playCount + increment;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error: Overflow terjadi - {ex.Message}");
                Console.WriteLine($"Play count sebelum: {this.playCount}");
                Console.WriteLine($"Increment: {increment}");
            }
        }

        // Method untuk menampilkan detail video
        public void PrintVideoDetails()
        {
            Console.WriteLine($"Video ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TEST DESIGN BY CONTRACT ===\n");

            // TEST 1: Normal case
            Console.WriteLine("--- Test 1: Normal Case ---");
            try
            {
                SayaTubeVideo video1 = new SayaTubeVideo("Tutorial Design By Contract – Muhamad Rozi");
                video1.IncreasePlayCount(100);
                video1.IncreasePlayCount(50);
                video1.PrintVideoDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();

            // TEST 2: Precondition - Judul null
            Console.WriteLine("--- Test 2: Judul Null ---");
            try
            {
                SayaTubeVideo video2 = new SayaTubeVideo(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();

            // TEST 3: Precondition - Judul > 100 karakter
            Console.WriteLine("--- Test 3: Judul > 100 Karakter ---");
            try
            {
                string longTitle = new string('A', 101);
                SayaTubeVideo video3 = new SayaTubeVideo(longTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();

            // TEST 4: Precondition - Increment > 10.000.000
            Console.WriteLine("--- Test 4: Increment > 10.000.000 ---");
            try
            {
                SayaTubeVideo video4 = new SayaTubeVideo("Test Video");
                video4.IncreasePlayCount(10000001);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();

            // TEST 5: Exception - Overflow (dengan loop untuk mempercepat)
            Console.WriteLine("--- Test 5: Overflow Exception ---");
            try
            {
                SayaTubeVideo video5 = new SayaTubeVideo("Overflow Test");
                video5.IncreasePlayCount(int.MaxValue - 100);
                video5.IncreasePlayCount(200); // Ini akan menyebabkan overflow
                video5.PrintVideoDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("=== ALL TESTS COMPLETED ===");
        }
    }
}