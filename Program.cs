using System.Linq;

namespace Linq;
public static class Program {
    private static void Main() {
        var query = new LinqQueries();
        //ImprimirValores(query.TodaLaColeccion());

        //ImprimirValores(query.LibrosDespuesDel2000());

        //ImprimirValores(query.LibrosConMas250PagesyPalabraInAction());

        //Console.WriteLine($"Todos los libros contienen Status: {query.TodosLibrosTienenStatus()}");

        //Console.WriteLine($"Algun libro publicado en el 2005: {query.AlgunLibroPublicadoEn2005()}");

        //ImprimirValores(query.LibrosPython());

        //ImprimirValores(query.LibrosJavaOrdenados());

        //ImprimirValores(query.LibrosMas450PagesOrder());

        //ImprimirValores(query.TresLibrosFechaPublicacionReciente());

        //ImprimirValores(query.TerceryCuartoLibroMore400Pages());

        //ImprimirValores(query.NameAndPagesThreeFirstBook());

        //Console.WriteLine($"Numero de libros con número de páginas entre 500 y 200: {query.NumBooksBetween200And500()}");

        // Console.WriteLine($"Fecha libro mas antigua {query.FechaPublicacionLibroMasAntiguo()}");

        //Console.WriteLine($"Cantidad de paginas del libro con mas paginas en la colección: {query.MasPaginasDeLibros()}");

        // var libroMenorPaginas = query.LibroConMenorPaginas();
        // Console.WriteLine($"Libro con menor paginas (mayor a 0) {libroMenorPaginas.Title} - {libroMenorPaginas.PageCount}");

        // var libroFechaMasReciente = query.LibroConFechaPublicacioMasReciente();
        // Console.WriteLine($"Libro Fecha de publicación mas reciente {libroFechaMasReciente.Title} - {libroFechaMasReciente.PageCount} - {libroFechaMasReciente.PublishedDate}");

        Console.WriteLine($"Suma paginas libros con paginas entre 0  y 500: {query.SumaPaginasLibros()}");
    }
    public static void ImprimirValores(IEnumerable<Book> Listalibros) {
        Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha Publicación");

        foreach (var item in Listalibros) {
            Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}