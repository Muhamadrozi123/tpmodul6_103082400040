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
            // Generate random 5-digit ID
            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        // Method untuk menambah play count
        public void IncreasePlayCount(int increment)
        {
            this.playCount += increment;
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
            // Buat video dengan judul sesuai nama praktikan
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Muhamad Rozi");

            // Tambah play count
            video.IncreasePlayCount(100);
            video.IncreasePlayCount(50);

            // Tampilkan detail
            Console.WriteLine("=== Video Details ===");
            video.PrintVideoDetails();
        }
    }
}
