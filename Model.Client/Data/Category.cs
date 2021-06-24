using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
   public  class Category
    {
        public int Id { get; private set; }//On interdit la modif de id dans l'application web
        public string Name { get; set; }

        //Constructeur que nous allons appeler dans notre application web
        public Category(string name)
        {
            Name = name;
        }

        //constructeur que nous allons utiliser dans notre mappers
        internal Category(int id, string name) 
            : this(name)
        {
            Id = id;
        }
    }
}
