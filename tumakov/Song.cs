using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    internal class Song
    {
        public string Name { get; private set; } // Название песни
        public string Author { get; private set; } // Автор песни
        public Song Prev { get; private set; }    // Указатель на предыдущую песню
        // Конструктор 1: название и автор, предыдущая песня - null
        public Song(string name, string author) : this(name, author, null) { }
        // Конструктор 2: название, автор и предыдущая песня
        public Song(string name, string author, Song prevSong)
        {
            Name = name;
            Author = author;
            Prev = prevSong;
        }
        // Конструктор по умолчанию (для решения проблемы в Main)
        public Song() : this("", "") { }
        // Метод для вывода данных о песне на печать
        public void PrintSongInfo()
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Author))
            {
                Console.WriteLine("Информация о песне отсутствует.");
                return;
            }
            Console.WriteLine($"Название: {Name}, Автор: {Author}");
            if (Prev != null)
            {
                Console.WriteLine($"Предыдущая песня: {Prev.Title()}");
            }
        }
        // Метод для возврата названия песни и исполнителя
        public string Title()
        {
            return string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Author) ? "Информация о песне отсутствует" : $"{Name} - {Author}";
        }
        // Метод для сравнения двух объектов-песен (переопределение Equals)
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song other = (Song)obj;
            return Name == other.Name && Author == other.Author;
        }
        // Переопределение GetHashCode для корректной работы с Equals
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Author.GetHashCode();
        }
        // Переопределение оператора == для сравнения песен
        public static bool operator ==(Song song1, Song song2)
        {
            if (ReferenceEquals(song1, song2))
            {
                return true;
            }
            if (ReferenceEquals(song1, null) || ReferenceEquals(song2, null))
            {
                return false;
            }

            return song1.Equals(song2);
        }
        // Переопределение оператора != для сравнения песен
        public static bool operator !=(Song song1, Song song2)
        {
            return !(song1 == song2);
        }
    }
}
