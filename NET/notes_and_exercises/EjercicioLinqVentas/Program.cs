﻿using EjercicioLinqVentas.Clases;
using EjercicioLinqVentas.Entidades;
using EjercicioLinqVentas.Interfaces;

IDataService dataService = new DataService();
int? paginas = null;
int? itemsPaginas = null;
string? procDesc = null;
string? tpDesck = null;
int? importeMin = null;
int? importeMax = null;
DateTime? fechaInicio = null;
//DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
DateTime? fechaFin = new DateTime(2022, 3, 2);
ProductosRespuesta VentasQuery1 = dataService.buscarProductos(paginas, itemsPaginas, procDesc, tpDesck, importeMin, importeMax, fechaInicio, fechaFin);
Console.WriteLine($"Página {VentasQuery1.Paginas}, items{VentasQuery1.ResultadosPorPagina}/{VentasQuery1.Total}");
foreach (ProductoExtendido producto in VentasQuery1.Productos)
{
    Console.WriteLine($"Producto :{producto.Descripcion}\nTipo de producto: {producto.TipoProducto}\nUnidades: {producto.Cantidad}\nImporte TOTAL: {(float)producto.Importe}\n");
}
Console.WriteLine("DESDE AQUI");
ProductosRespuesta VentasQuery2 = dataService.buscarProductosBDD(paginas, itemsPaginas, procDesc, tpDesck, importeMin, importeMax, fechaInicio, fechaFin);
Console.WriteLine($"Página {VentasQuery2.Paginas}, items{VentasQuery2.ResultadosPorPagina}/{VentasQuery2.Total}");
foreach (ProductoExtendido producto in VentasQuery2.Productos)
{
    Console.WriteLine($"Producto :{producto.Descripcion}\nTipo de producto: {producto.TipoProducto}\nUnidades: {producto.Cantidad}\nImporte TOTAL: {(float)producto.Importe}\n");
}


