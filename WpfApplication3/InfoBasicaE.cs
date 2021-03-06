﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class InfoBasicaE
    {
        
        public int    id_candidato { get; set; }
        public string nombre { get; set; }
        public int    id_genero { get; set; }
        public string telefono_celular { get; set; }
        public string telefono_fijo { get; set; }
        public string profesion { get; set; }
        public string correo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int    id_municipio { get; set; }
        public string direccion { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string AFP { get; set; }
        public string ISSS { get; set; }
        public int id_situacionProfesional { get; set; }
        public int edad { get; set; }

        public InfoBasicaE() { }
        public InfoBasicaE(int pId_candidato, string pNombre, int pId_genero , string pTelefono_celular, string pTelefono_fijo, string pProfesion,
                    string pCorreo, DateTime pFecha_nacimiento,int pId_municipio ,string pDireccion, string pDUI, string pNIT, string pAFP,
                    string PISSS,  int pId_situacionProfesional,int PEdad)
        {

            id_candidato = pId_candidato;
            nombre = pNombre;
            id_genero = pId_genero;
            telefono_celular = pTelefono_celular;
            telefono_fijo = pTelefono_fijo;
            profesion = pProfesion;
            correo = pCorreo;
            fecha_nacimiento = pFecha_nacimiento;
            id_municipio = pId_municipio ;
            direccion = pDireccion;
            DUI = pDUI;
            NIT = pNIT;
            AFP = pAFP;
            ISSS = PISSS;
            id_situacionProfesional = pId_situacionProfesional;
            edad = PEdad; 
        

        }
    }
}
