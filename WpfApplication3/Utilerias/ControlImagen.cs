﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;

using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows;

namespace WpfApplication3.Utilerias
{
    public static class ControlImagen
    {
        //Codigo Para Imagenes Normales
        //Obtener Imagen Desde Un Archivo **************************************************
        public static Imagenes ObtenerImageDesdeUnArchivo(Imagenes pImagen)
        {

            Imagenes _Imagen = new Imagenes();
            OpenFileDialog FileBrowser = new OpenFileDialog();
            FileBrowser.Filter = "Archivos de imágen (.jpg)|*.jpg|All Files (.)|*.*";
            FileBrowser.FilterIndex = 1;
            FileBrowser.Multiselect = false;
            bool? checarOK = FileBrowser.ShowDialog();

            if (checarOK == true)
            {
                string rutaDestino = @"C:\Imagenes\Fotos";
                if (!Directory.Exists(rutaDestino))
                    Directory.CreateDirectory(rutaDestino);

                _Imagen.RutaImagen = FileBrowser.FileName;
                _Imagen.OnlyName = FileBrowser.SafeFileName;
                BitmapImage _BitmapImage = new BitmapImage(new Uri(FileBrowser.FileName));
                _Imagen.ImagenEnObjeto = _BitmapImage;
            }
            return _Imagen;

        }
        //*************************************************************************************
        //Obtener Imagen En Binarios *****************************************
        public static Imagenes ObtenerImageEnBinario(string PathFoto)
        {
            Imagenes _Imagen = new Imagenes();
            byte[] bytesImage = File.ReadAllBytes(PathFoto);
            _Imagen.ImagenEnBinario = bytesImage;
            return _Imagen;
        }
        //********************************************************************
        // Obtener Imagen En Objecto *****************************************************
        public static Imagenes ObtenerImagenEnObjecto(byte[] pByte)
        {
            Imagenes _Imagen = new Imagenes();

            BitmapImage Bitmapimagen = new BitmapImage();
            Bitmapimagen.BeginInit();
            MemoryStream stri = new MemoryStream(pByte, 0, pByte.Length, false, false);
            Bitmapimagen.StreamSource = stri;
            Bitmapimagen.EndInit();
            _Imagen.ImagenEnObjeto = Bitmapimagen;
            return _Imagen;
        }
        //**********************************************************************************
        // Obtener Imagen En Objecto *****************************************************
        public static BitmapImage ObtenerImagenEnObjecto2(byte[] pByte)
        {
            BitmapImage Bitmapimagen = new BitmapImage();
            Bitmapimagen.BeginInit();
            MemoryStream stri = new MemoryStream(pByte, 0, pByte.Length, false, false);
            Bitmapimagen.StreamSource = stri;
            Bitmapimagen.EndInit();
            return Bitmapimagen;
        }
        //**********************************************************************************
        //***********************************************************************************
        public static Imagenes GuardarImagenEnRuta(Imagenes pimagen)
        {
            string archivoOrigen = pimagen.RutaImagen;
            string rutaDestino = @"C:\Imagenes\Fotos\";
            string rutadefault = @"User_default\";
            if (!Directory.Exists(rutaDestino))
                Directory.CreateDirectory(rutaDestino);
            if (!Directory.Exists(rutaDestino + rutadefault))
                Directory.CreateDirectory(rutaDestino + rutadefault);

            if (!File.Exists(rutaDestino + rutadefault + "Userman.png"))
            {
                string p = rutaDestino + rutadefault + "Userman.png";
                string rutaOrigenDefaultMan = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\User_default\\Userman.png";
                System.IO.File.Copy(rutaOrigenDefaultMan, rutaDestino + rutadefault + "Userman.png", true);
            }
            if (!File.Exists(rutaDestino + rutadefault + "userwoman.png"))
            {
                string rutaOrigenDefaultMan = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\User_default\\userwoman.png";
                System.IO.File.Copy(rutaOrigenDefaultMan, rutaDestino + rutadefault + "userwoman.png", true);
            }
            string archivoDestino = System.IO.Path.Combine(rutaDestino, pimagen.OnlyName);

            if (!(siExisteImagen(pimagen)))
                System.IO.File.Copy(archivoOrigen, archivoDestino, true);
            return pimagen;
        }
        public static void EliminarImagenEnRuta(string pimagen)
        {
            string rutaDestino = @"C:\Imagenes\Fotos\";
            //string rutaDestino = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\";
            string archivoDestino = System.IO.Path.Combine(rutaDestino, pimagen);
            System.IO.File.Delete(archivoDestino);
        }
        /*Proceso de facebook en la obtencion de imagen por el tipo de genero*/
        public static BitmapImage ObtenerImagenEnObjetoUri(Imagenes pImagen)
        {
            string rutaDestino = @"C:\\Imagenes\\Fotos\\";
            pImagen.Psexo = pImagen.Psexo == "1" ? @"User_default\Userman.png" : @"User_default\userwoman.png";

            pImagen.OnlyName = pImagen.OnlyName == "" || pImagen.OnlyName == null ? pImagen.Psexo : pImagen.OnlyName;
            // Create the image element.
            Image simpleImage = new Image();
            simpleImage.Width = 200;
            simpleImage.Margin = new Thickness(5);
            // Create source.


            try
            {
                BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri(rutaDestino + pImagen.OnlyName, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                simpleImage.Source = bi;
                return bi;
            }
            catch
            {
                BitmapImage bi2 = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi2.BeginInit();
                bi2.UriSource = new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\" + pImagen.OnlyName.Replace(pImagen.OnlyName, pImagen.Psexo), UriKind.RelativeOrAbsolute);
                bi2.EndInit();
                // Set the image source.
                simpleImage.Source = bi2;
                return bi2;
            }
        }
        public static bool siExisteImagen(Imagenes pimagen)
        {
            bool resultado = false;

            string Name = pimagen.Deleteimagen;
            string curFile = @"C:\Imagenes\Fotos\" + pimagen.OnlyName;
            if (File.Exists(curFile))
            {
                resultado = true;
                if (!(pimagen.Deleteimagen == "" ||pimagen.Deleteimagen ==null))
                {
                    ControlImagen.EliminarImagenEnRuta(Name);
                }
            }
            else
                resultado = false;

            return resultado;
        }
        #region MetodoAnteriores
        //public static BitmapImage ObtenerImagenEnObjetoUri(Imagenes pImagen)
        //{
        //    pImagen.Psexo = pImagen.Psexo == "1" ? @"User_default\Userman.png" : @"User_default\userwoman.png";

        //    pImagen.OnlyName = pImagen.OnlyName == "" || pImagen.OnlyName == null ? pImagen.Psexo : pImagen.OnlyName;
        //    // Create the image element.
        //    Image simpleImage = new Image();
        //    simpleImage.Width = 200;
        //    simpleImage.Margin = new Thickness(5);
        //    // Create source.


        //    try
        //    {
        //        BitmapImage bi = new BitmapImage();
        //        // BitmapImage.UriSource must be in a BeginInit/EndInit block.
        //        bi.BeginInit();
        //        bi.UriSource = new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\" + pImagen.OnlyName, UriKind.RelativeOrAbsolute);
        //        bi.EndInit();
        //        // Set the image source.
        //        simpleImage.Source = bi;
        //        return bi;
        //    }
        //    catch
        //    {
        //        BitmapImage bi2 = new BitmapImage();
        //        // BitmapImage.UriSource must be in a BeginInit/EndInit block.
        //        bi2.BeginInit();
        //        bi2.UriSource = new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\Imagenes\\Fotos\\" + pImagen.OnlyName.Replace(pImagen.OnlyName, pImagen.Psexo), UriKind.RelativeOrAbsolute);
        //        bi2.EndInit();
        //        // Set the image source.
        //        simpleImage.Source = bi2;
        //        return bi2;
        //    }
        //}
        #endregion
    }
}
