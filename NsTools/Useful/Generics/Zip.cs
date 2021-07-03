using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using NsTools.Exceptions;
using System.IO;

namespace NsTools.Useful.Generics
{
    class Zip
    {
        private string _source { get; set; }
        private string _target { get; set; }
        public Zip(string source, string target)
        {
            _source = source;
            _target = target;
        }
        public void Unzip()
        {
            try
            {
                ZipFile.ExtractToDirectory(_source, _target);
            }
            catch (ArgumentException e)
            {
                throw new ZipExceptions(e.Message);
            }
            catch (PathTooLongException e)
            {
                throw new ZipExceptions(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new ZipExceptions(e.Message);
            }

            catch (IOException e)
            {
                throw new ZipExceptions(e.Message);
            }

            catch (UnauthorizedAccessException e)
            {
                throw new ZipExceptions(e.Message);
            }

            catch (NotSupportedException e)
            {
                throw new ZipExceptions(e.Message);
            }

            catch (InvalidDataException e)
            {
                throw new ZipExceptions(e.Message);
            }
        }
    }
}
