using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlosarioArchivos
{
    public static class SafeFileEnumerator
    {
        public static IEnumerable<string> EnumerateDirectories(string parentDirectory, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var directories = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    directories = Directory.EnumerateDirectories(parentDirectory)
                        .SelectMany(x => EnumerateDirectories(x, searchPattern, searchOpt));
                }
                return directories.Concat(Directory.EnumerateDirectories(parentDirectory, searchPattern));
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var dirFiles = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    dirFiles = Directory.EnumerateDirectories(path)
                                        .SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));
                }
                return dirFiles.Concat(Directory.EnumerateFiles(path, searchPattern));
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();

            pending.Push(root);

            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;

                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }

                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;

                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }

        public static IEnumerable<ListaArchivosBulk> GetFilesAdv(string root, string searchPattern, Guid id)
        {
            Stack<string> pending = new Stack<string>();
            ListaArchivosBulk lista = new ListaArchivosBulk();

            pending.Push(root);

            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;

                try
                {
                    next = Delimon.Win32.IO.Directory.GetFiles(path, searchPattern);
                }
                catch { }

                if (next != null && next.Length != 0)
                {
                    foreach (var file in next)
                    {
                        lista = new ListaArchivosBulk();
                        lista.Id = id;
                        lista.Ruta = file;
                        lista.Tipo = "A";
                        yield return lista;
                    }

                    lista = new ListaArchivosBulk();
                    lista.Id = id;
                    lista.Ruta = path;
                    lista.Tipo = "C";
                    yield return lista;
                }

                try
                {
                    next = Delimon.Win32.IO.Directory.GetDirectories(path);

                    foreach (var subdir in next)
                        pending.Push(subdir);
                }
                catch { }
            }
        }

        public static IEnumerable<string> GetFiles(string root, string searchPattern, List<string> Filter)
        {
            Stack<string> pending = new Stack<string>();

            pending.Push(root);

            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;

                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }

                if (next != null && next.Length != 0)
                {
                    foreach (var file in next)
                        yield return file;
                }

                try
                {
                    next = Directory.GetDirectories(path);

                    foreach (var subdir in next)
                    {
                        foreach (string Excl in Filter)
                        {
                            if (!subdir.Contains(Excl))
                            {
                                pending.Push(subdir);
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }

    public class ListaArchivosBulk
    {
        public virtual Guid Id { get; set; }
        public virtual string Ruta { get; set; }
        public virtual string Tipo { get; set; }
    }
}