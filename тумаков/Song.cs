using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков
{
    public class Song
    {
        private string name;   
        private string author; 
        private Song prev; 

        public void FillName()
        {
            Console.Write("Введите название песни: ");
            name = Console.ReadLine();
        }
        public void FillAuthor()
        { 
            Console.Write("Введите автора песни: ");
            author = Console.ReadLine();
        }
        public void SetPrevSong(Song previousSong)
        {
            prev = previousSong;
        }
        public string Title()
        {
            return $"{name} - {author}"; 
        }
        public override bool Equals(object d)
        {
            if (d is Song other)
            {
                return this.name == other.name && this.author == other.author; 
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (name, author).GetHashCode();
        }
    }
}
