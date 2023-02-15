using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq {
    public class LinqQueries {
        private List<Book>? _librosCollection { get; set; } = new List<Book>();
        public LinqQueries() {
            using var reader = new StreamReader("./books.json");
            string json = reader.ReadToEnd();
            this._librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Book> TodaLaColeccion() {
            return _librosCollection ?? Enumerable.Empty<Book>();
        }

        public IEnumerable<Book> LibrosDespuesDel2000() {
            //Extension Method
            //return _librosCollection?.Where(p => p.PublishedDate.Year > 2000) ?? Enumerable.Empty<Book>(); 

            //QueryExpression
            return from l in _librosCollection where l.PublishedDate.Year > 2000 select l;
        }

        public IEnumerable<Book> LibrosConMas250PagesyPalabraInAction() {
            //extension Method
            //return _librosCollection?.Where(l=> l.PageCount > 250 && l.Title.Contains("Action")) ?? Enumerable.Empty<Book>();

            //Query Expression
            return from l in _librosCollection where l.PageCount > 250 && l.Title.Contains("Action") select l;
        }

        public bool TodosLibrosTienenStatus() {
            //Extension Method
            return _librosCollection.All(l => l.Status != string.Empty);

            //Query Expression
            //return (from l in _librosCollection where l.Status != string.Empty select l) != Enumerable.Empty<Book>() ? true : false;
        }

        public bool AlgunLibroPublicadoEn2005() {
            //ExtensionMethod
            return _librosCollection.Any(l => l.PublishedDate.Year == 2005);

            //Query Expression
            //return (from l in _librosCollection where l.PublishedDate.Year == 2005 select l) != Enumerable.Empty<Book>() ? true : false;
        }

        public IEnumerable<Book> LibrosPython() {
            //Extension Method
            //return _librosCollection.Where(p => p.Categories.Contains("Python"));

            //Query Expression
            return from l in _librosCollection where l.Categories.Contains("Python") select l;
        }

        public IEnumerable<Book> LibrosJavaOrdenados() {
            //Method extension
            //return _librosCollection.Where(l => l.Categories.Contains("Java")).OrderBy(l => l.Title);
            //return _librosCollection.Where(l => l.Categories.Contains("Java")).OrderByDescending(l => l.PageCount).ThenBy(l => l.Title); //Agregando mas ordenación de elementos

            //Query Expression
            return from l in _librosCollection where l.Categories.Contains("Java") orderby l.Title, l.PageCount select l;
        }

        public IEnumerable<Book> LibrosMas450PagesOrder() {
            //Extension Method
            //return _librosCollection.Where(l => l.PageCount > 450).OrderByDescending(l => l.PageCount);

            //Query Expresion
            return from l in _librosCollection where l.PageCount > 450 orderby l.PageCount descending select l;
        }

        public IEnumerable<Book> TresLibrosFechaPublicacionReciente() {
            //Extension Method
            //return _librosCollection.Where(l => l.Categories.Contains("Java")).OrderByDescending(l => l.PublishedDate.Year).Take(3);

            //Query Expresion
            return (from l in _librosCollection where l.Categories.Contains("Java") orderby l.PublishedDate.Year descending select l).Take(3);
        }

        public IEnumerable<Book> TerceryCuartoLibroMore400Pages() {
            //Extension Method
            //return _librosCollection.Where(l => l.PageCount > 400).Take(4).Skip(2);

            //Query Expression
            return (from l in _librosCollection where l.PageCount > 400 select l).Take(4).Skip(2);
        }

        public IEnumerable<Book> NameAndPagesThreeFirstBook() {
            //extension method
            //return _librosCollection.Take(3).Select(l => new Book() { Title = l.Title, PageCount = l.PageCount });

            //Query Expression
            return (from l in _librosCollection select new Book() { Title = l.Title, PageCount = l.PageCount }).Take(3);
        }

        //Operadores de agregacion
        public int NumBooksBetween200And500() {
            //Extension Method
            //return _librosCollection.Where(l => l.PageCount < 500 && l.PageCount > 200).Count();
            return _librosCollection.Count(l => l.PageCount < 500 && l.PageCount > 200);

            //Query Expression
            //return (from l in _librosCollection where l.PageCount < 500 && l.PageCount > 200 select l).Count();
        }

        public DateTime FechaPublicacionLibroMasAntiguo() {
            return _librosCollection.Min(p => p.PublishedDate);
        }

        public int? MasPaginasDeLibros() {
            return _librosCollection.Max(l => l.PageCount);
        }

        //MinBy and MinBy used to get the object filtered
        public Book LibroConMenorPaginas() {
            return _librosCollection.Where(l => l.PageCount > 0).MinBy(l => l.PageCount);
        }

        public Book LibroConFechaPublicacioMasReciente() {
            return _librosCollection.MaxBy(l => l.PublishedDate);
        }

        public int? SumaPaginasLibros() {
            return _librosCollection.Where(l => l.PageCount >= 0 && l.PageCount <= 500).Sum(l => l.PageCount);
        }

        public string TitulosLibrosFechaPosterior2015() {
            return _librosCollection.Where(l => l.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) => {
                if (!string.IsNullOrEmpty(TitulosLibros)) {
                    TitulosLibros += " - " + next.Title;
                } else {
                    TitulosLibros += next.Title;
                }
                return TitulosLibros;
            });
        }

        public double PromedioCaracteresTitulosLibros() {
            return _librosCollection.Average(l => l.Title.Length);
        }

        //Clausulas de agrupamiento
        public IEnumerable<IGrouping<int, Book>> LibroPublicadosDesde2000AgrupadosPorAnio() {
            //Extension Method
            //return _librosCollection.Where(l => l.PublishedDate.Year > 2000).GroupBy(l => l.PublishedDate.Year);

            //Query Expression
            return from l in _librosCollection where l.PublishedDate.Year > 2000 group l by l.PublishedDate.Year;
        }
    }
}