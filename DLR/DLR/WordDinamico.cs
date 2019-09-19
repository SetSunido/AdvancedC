using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace DLR
{
    public class Data
    {
        public string Title { get; set; }
        public string Details { get; set; }
    }

    public class WordDinamico : IDisposable
    {
        public string output = @"C:\Users\José Ramón Sagarna\Documents\data.docx";
        private IEnumerable<Data> data;

        // Declarar objeto dinamico
        dynamic _word;

        public WordDinamico(IEnumerable<Data> data)
        {
            this.data = data;
        }

        public void WriteToWordDocument()
        {
            //Instanciar objeto Word
            _word = new Application();

            //Crear documento
            GenerateWordDocument();


            //Cerrar aplicacion
            _word.Quit();
        }

        private void GenerateWordDocument()
        {
            CreateDocument();

            AppendText("Informe Rendimiento", true, true);

            InsertNewLine();

            var contador = 1;

            foreach (var item in data)
            {
                AppendText(string.Format("{0}{1}", contador, item.Title), true, false);

                InsertNewLine();

                AppendText(item.Details, false, false);

                InsertNewLine();

                InsertNewLine();

                contador++;

            }

            Save();

        }

        private void Save()
        {
            //Comprobar si existe
            if (File.Exists(output))
            {

                //Eliminar
                File.Delete(output);
            }
            var currentDocument = _word.ActiveDocument;

            currentDocument.SaveAs(output);

            currentDocument.Close();


        }

        private void InsertNewLine()
        {
            //Deplazar a final del documento

            var currentLocation = GetEndOfDocument();

            currentLocation.InsertBreak(WdBreakType.wdLineBreak);
        }

        private void AppendText(string texto, bool negrita, bool subrayado)
        {
            //Deplazar a final del documento
            var currentLocation = GetEndOfDocument();
            currentLocation.Bold = negrita ? 1 : 0;
            currentLocation.Underline = subrayado ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;

            currentLocation.InsertAfter(texto);

        }

        private Range GetEndOfDocument()
        {
            //Recuperar el final documento actual
            var endOfDocument = _word.ActiveDocument.Content.End - 1;

            return _word.ActiveDocument.Range(endOfDocument);
        }

        private void CreateDocument()
        {
            //Crear y activar documento de Word en blanco
            _word.Documents.Add.Activate();
        }

        #region "Disposable"
        bool isDisposed = false;
        
        /*
         * Destructor (CLR). Eliminar si no lo están, recursos no administrados.
         */
         
        ~WordDinamico()
        {
            Dispose(false);
        }

        protected virtual void Dispose (bool isDisposing)
        {

            if (!isDisposed)

            {
                if (isDisposing)
                {
                    //Liberar recursos administrados
                    if(_word !=null)
                    {
                        _word.Quit();
                    }
                }

                //Liberar recursos no administrados
                if (_word != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_word);
                }



                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            //Indicar GC que no haga nada con el objeto

            GC.SuppressFinalize(this);
                
        }
        #endregion
    }

}

