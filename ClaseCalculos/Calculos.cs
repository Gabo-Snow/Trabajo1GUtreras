using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseCalculos
{
    public class Calculos
    {

        public int PrecioSuma { get; set; }
        public int PrecioMascota { get; set; }

        public int ValorVentaNeto(int PrecioSuma, int PrecioMascota)
        {
            return PrecioSuma + PrecioMascota;
        } 

        public Double Descuento (int ValorVentaNeto)
        {
            Double MontoDescuentoFloat = 0;

            if (ValorVentaNeto <= 0 && ValorVentaNeto <= 25000)
            {
                MontoDescuentoFloat = ValorVentaNeto;
                
            }
            else if (ValorVentaNeto > 25000 && ValorVentaNeto <= 100000)
            {
                MontoDescuentoFloat = ValorVentaNeto * 0.05;
            }
            else if (ValorVentaNeto > 100000 && ValorVentaNeto <= 250000)
            {
                MontoDescuentoFloat = ValorVentaNeto * 0.10;
            }
            else if (ValorVentaNeto > 250000)
            {
                MontoDescuentoFloat = ValorVentaNeto * 0.15;
            }

            return MontoDescuentoFloat;
            
        }

        public string PorcentajeDescuento ( int ValorVentaNeto)
        {
            string PorcentajeDescuento = "";

            if (ValorVentaNeto <= 0 && ValorVentaNeto <= 25000)
            {
                PorcentajeDescuento = "0%";

            }
            else if (ValorVentaNeto > 25000 && ValorVentaNeto <= 100000)
            {
                PorcentajeDescuento = "5%";
            }
            else if (ValorVentaNeto > 100000 && ValorVentaNeto <= 250000)
            {
                PorcentajeDescuento = "10%";
            }
            else if (ValorVentaNeto > 250000)
            {
                PorcentajeDescuento = "15%";
            }

            return PorcentajeDescuento;
        }

        public int ValorVenta (int ValorVentaNeto, int MontoDescuento)
        {
            return ValorVentaNeto - MontoDescuento;
        }
        public Double MontoIva (int ValorVenta, Double Iva = 0.19)
        {
            return ValorVenta * Iva;
        }

        public Double TotalVenta(int ValorVenta, Double Iva)
        {
            return ValorVenta + Iva;
        }

        public int CantidadDisponible { get; set; }
        public int CantidadVendida { get; set; }

        public int RestarDisponibles (int CantidadDisponible, int CantidadRestante)
        {
            return CantidadDisponible - CantidadRestante;
        }        

    }
}
