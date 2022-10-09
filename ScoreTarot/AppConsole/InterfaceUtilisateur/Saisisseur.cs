using System;
namespace Model
{ 
    public class Sasisseur
    {

        public String saisirString()
        {
            return Console.ReadLine();
        }

        public int? saisirInt()
        {
            String saisie = Console.ReadLine();
            try
            {
                int nombre = int.Parse(saisie);
                return nombre;
            }
            catch(Exception e)
            {
                return null;
            }

        }
    }
}

