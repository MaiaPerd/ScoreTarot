﻿using System;
namespace AppliConsole.InterfaceUtilisateur
{ 
    public class Sasisseur
    {

        public String SaisirString()
        {
            return Console.ReadLine();
        }

        public int? SaisirInt()
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

