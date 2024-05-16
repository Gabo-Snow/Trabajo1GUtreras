using ClaseCalculos;
using ClaseMascota;
using System;

namespace Trabajo1GUtreras
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Atributos

            int cantidadDisponible = 0;
            string nombreTienda = "";
            bool esNumero;
            int totalVentaMascotas = 0;
            int contadorCantidad = 0;
            int cantidadVenta = 0;
            int tipoVenta = 0;
            string opcionRaza = "";
            string opcionComprador = "";
            string terminarVenta = "";

            #endregion

            #region Datos Mascota

            int idMascota = 0;
            string nombreMascota = "";
            string razaMascota = "";
            int edadMascota = 0;
            int sexoMascota = 0;
            int precioMascota = 0;
            string rutComprador = "";
            string nombreComprador = "";

            #endregion

            #region Inicialización de Clases

            Mascota mascota = new Mascota();

            Calculos totalNeto = new Calculos();
            var valorVentaNeto = totalNeto.ValorVentaNeto(totalVentaMascotas, precioMascota);

            Calculos restarCantidad = new Calculos();
            var resta = restarCantidad.RestarDisponibles(cantidadDisponible, 0);

            Calculos descuento = new Calculos();
            var montoDescuento = descuento.Descuento(valorVentaNeto);

            Calculos porcDescuento = new Calculos();
            var porcentajeDescto = porcDescuento.PorcentajeDescuento(valorVentaNeto);

            Calculos valorV = new Calculos();
            var valorVenta = valorV.ValorVenta(valorVentaNeto, (int)montoDescuento);

            Calculos iva = new Calculos();
            var valorIva = iva.MontoIva(valorVenta);

            Calculos totalV = new Calculos();
            var totalVenta = totalV.TotalVenta(valorVenta, valorIva);


            #endregion

            do
            {
                Console.Write("Escriba el nombre de la tienda de Mascotas: ");
                nombreTienda = Console.ReadLine();
                if (string.IsNullOrEmpty(nombreTienda))
                {
                    Console.WriteLine("Campo no puede estar vacío");
                }
                else
                {
                    Console.WriteLine("Nombre de la tienda <" + nombreTienda + "> ingresado con éxito");
                }
            } while (string.IsNullOrEmpty(nombreTienda));
            do
            {
                Console.Write("Ingrese la cantidad de mascotas disponibles para vender: ");
                esNumero = int.TryParse(Console.ReadLine(), out cantidadDisponible);
                if (!esNumero)
                {
                    Console.WriteLine("Debe ingresar un campo numérico");
                }
                if (esNumero && (cantidadDisponible <= 0) || (cantidadDisponible >= 1000))
                {
                    Console.WriteLine("Ddebe ingresar una cantidad mayor a 0 o menor o igual a 1000");
                }

            } while ((!esNumero) || (cantidadDisponible <= 0) || (cantidadDisponible >= 1000));


            if (cantidadDisponible >= 0 && cantidadDisponible <= 1000)
            {

                cantidadVenta = 0;
                contadorCantidad = 1;
                string opcion = "";

                do
                {

                    do
                    {

                        if (resta > 0)
                        {
                            Console.WriteLine("La cantidad de mascotas disponibles para vender es: " + resta);
                        }
                        else
                        {
                            Console.WriteLine("La cantidad de mascotas disponibles para vender es: " + cantidadDisponible);
                        }


                        Console.Write("Si deseas vender escribe la palabra <VENDER>, para salir escribe <SALIR>: ");
                        opcion = Console.ReadLine().ToUpper().Trim();

                        if ((!opcion.Equals("SALIR")) && (!opcion.Equals("VENDER")))
                        {
                            Console.WriteLine("Opción inválida, intente nuevamente");
                        }

                    } while (!opcion.Equals("SALIR") && (!opcion.Equals("VENDER")));

                    if (opcion.Equals("VENDER"))
                    {

                        if (tipoVenta == 0)
                        {
                            do
                            {
                                Console.Write("Ingrese cantidad de mascotas que venderá: ");
                                esNumero = int.TryParse(Console.ReadLine(), out cantidadVenta);
                                if (!esNumero)
                                {
                                    Console.WriteLine("Campo debe ser numérico");
                                }
                                if (cantidadVenta > cantidadDisponible)
                                {
                                    Console.WriteLine("Cantidad ingresadada excede la cantidad disponible, intente nuevamente");
                                }
                                if ((cantidadVenta <= 0) && (esNumero))
                                {
                                    Console.WriteLine("Cantidad a vender debe ser mayor a 0");
                                }

                            } while ((!esNumero) || cantidadVenta <= 0 || (cantidadVenta > cantidadDisponible));
                        }
                        else if (tipoVenta > 0)
                        {
                            do
                            {
                                Console.WriteLine("Tiene <" + resta + "> mascotas disponibles para vender");
                                Console.Write("Ingrese cantidad de mascotas que venderá: ");
                                esNumero = int.TryParse(Console.ReadLine(), out cantidadVenta);
                                if (!esNumero)
                                {
                                    Console.WriteLine("Campo debe ser numérico");
                                }
                                if (cantidadVenta > resta)
                                {
                                    Console.WriteLine("Cantidad ingresadada excede la cantidad disponible, intente nuevamente");
                                }
                                if ((cantidadVenta <= 0) && (esNumero))
                                {
                                    Console.WriteLine("Cantidad a vender debe ser mayor a 0");
                                }

                            } while ((!esNumero) || cantidadVenta <= 0 || (cantidadVenta > resta));
                        }

                        if (cantidadDisponible >= cantidadVenta)
                        {
                           
                            if (tipoVenta == 0)
                            {
                                do
                                {
                                    Console.Write("Todas las mascotas serán vendidas al mismo Comprador? SI/NO: ");
                                    opcionComprador = Console.ReadLine().ToUpper().Trim();

                                    if (!opcionComprador.Equals("SI") && (!opcionComprador.Equals("NO")))
                                    {
                                        Console.WriteLine("Opción inválida");
                                    }

                                } while (!opcionComprador.Equals("SI") && (!opcionComprador.Equals("NO")));
                                do
                                {
                                    Console.Write("Todas las mascotas a vender son de la misma raza? SI/NO: ");
                                    opcionRaza = Console.ReadLine().ToUpper().Trim();

                                    if (!opcionRaza.Equals("SI") && (!opcionRaza.Equals("NO")))
                                    {
                                        Console.WriteLine("Opción inválida");
                                    }

                                } while (!opcionRaza.Equals("SI") && (!opcionRaza.Equals("NO")));

                            }

                            


                            if ((opcionRaza.Equals("SI") && opcionComprador.Equals("SI")) && ((tipoVenta == 0) || (tipoVenta == 1)))
                            {
                                tipoVenta = 1;

                                terminarVenta = "";

                                do
                                {
                                    Console.Write("Escriba la raza de las mascota: ");
                                    razaMascota = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(razaMascota))
                                    {
                                        Console.WriteLine("Debe ingresar al menos una raza, intente nuevamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Raza <" + razaMascota + "> >Ingresada correctamente");
                                    }
                                } while (string.IsNullOrEmpty(razaMascota));
                                do
                                {
                                    Console.Write("Ingrese el RUT del Comprador: ");
                                    rutComprador = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(rutComprador))
                                    {
                                        Console.WriteLine("Debe ingresar al menos un RUT para el comprador, intente nuevamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Rut Comprador <" + rutComprador + "> Ingresado correctamente");
                                    }
                                } while (string.IsNullOrWhiteSpace(rutComprador));
                                do
                                {
                                    Console.Write("Ingrese Nombre del Comprador: ");
                                    nombreComprador = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(nombreComprador))
                                    {
                                        Console.WriteLine("Debe ingresar al menos un Nombre para el comprador, intente nuevamente");
                                    }
                                    {
                                        Console.WriteLine("Nombre del Comprador <" + nombreComprador + "> Ingresado correctamente");
                                    }
                                } while (string.IsNullOrWhiteSpace(nombreComprador));
                                do
                                {

                                    Console.Write("Ingrese la ID numérica de la mascota N° <" + contadorCantidad + "> o escriba <TERMINAR> para finalizar: ");
                                    String tecladoUsuario = Console.ReadLine().Trim().ToUpper();
                                    Boolean soyNumero = false;

                                    if (int.TryParse(tecladoUsuario, out idMascota) && idMascota > 0)
                                    {
                                        Console.WriteLine("Hiciste lo correcto Bob");
                                        soyNumero = true;
                                    }
                                    else if (int.TryParse(tecladoUsuario, out idMascota) && idMascota <= 0)
                                    {
                                        Console.WriteLine("Sólo puede ingresar números mayores a 0, intente nuevamente");
                                    }
                                    else if (string.IsNullOrEmpty(tecladoUsuario))
                                    {
                                        Console.WriteLine("Debe ingresar un valor, intente nuevamente");
                                    }

                                    else if (tecladoUsuario.Equals("TERMINAR"))
                                    {

                                        do
                                        {
                                            Console.Write("Usted ha elegido terminar el proceso de venta, solo se guardarán los datos ingresados hasta ahora, para terminar escriba nuevamente <TERMINAR>, de lo contrario escriba <CONTINUAR>: ");
                                            terminarVenta = Console.ReadLine().Trim().ToUpper();
                                            if (terminarVenta.Equals("TERMINAR"))
                                            {

                                                Console.WriteLine("Se ha finalizado la venta actual");
                                            }
                                            else if (terminarVenta.Equals("CONTINUAR"))
                                            {
                                                Console.WriteLine("Usted ha elegido continuar la venta, siga ingresando los datos restantes");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opción ingresada no es válida, intente nuevamente");
                                            }

                                        } while (!terminarVenta.Equals("TERMINAR") && (!terminarVenta.Equals("CONTINUAR")));

                                    }
                                    else
                                    {
                                        Console.WriteLine("Opción ingresada no disponible, intente nuevamente");
                                    }


                                    if (idMascota > 0)
                                    {

                                        Console.WriteLine("La ID <" + idMascota + ">, de la mascota N° <" + contadorCantidad + ">, fue ingresada correctamente");

                                        do
                                        {
                                            Console.Write("Ingrese el nombre de la mascota N° <" + contadorCantidad + ">: ");
                                            nombreMascota = Console.ReadLine();

                                            if (string.IsNullOrEmpty(nombreMascota))
                                            {
                                                Console.WriteLine("Debe ingresar un Nombre para la mascota");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El nombre <" + nombreMascota + ">, de la mascota N° <" + contadorCantidad + ">, se registrado exitosamente");
                                            }

                                        } while (string.IsNullOrEmpty(nombreMascota));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese Edad de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out edadMascota) && edadMascota > 0 && edadMascota < 30)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito la edad <" + edadMascota + "> para la mascota N° <" + contadorCantidad + ">");
                                                soyNumero = true;
                                            }
                                            else if (int.TryParse(tecladoUsuario, out edadMascota) && (edadMascota <= 0) || (edadMascota >= 30))
                                            {
                                                Console.WriteLine("Sólo puede ingresar una edad entre 1 y 29 años, intente nuevamente");
                                            }
                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((edadMascota <= 0) || (edadMascota >= 30) || (!soyNumero));
                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el sexo de la Mascota N° <" + contadorCantidad + ">. Digite <1> para Macho o <2> para Hembra: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out sexoMascota) && sexoMascota > 0 && sexoMascota < 3)
                                            {

                                                if (sexoMascota == 1)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }
                                                else if (sexoMascota == 2)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }

                                            }
                                            else if (int.TryParse(tecladoUsuario, out sexoMascota) && (sexoMascota != 1) || (sexoMascota != 2))
                                            {
                                                Console.WriteLine("Sólo puede ingresar las alternativas <1> para macho y <2> para hembra, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((sexoMascota != 1) && (sexoMascota != 2));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el Valor de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota > 0)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito el valor de la mascota N° <" + contadorCantidad + ">, por un monto de: " + precioMascota);
                                                precioMascota = int.Parse(tecladoUsuario);
                                                soyNumero = true;
                                            }

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota <= 0)
                                            {
                                                Console.WriteLine("Valor de la mascota no puede ser inferior ni igual a $0");

                                            }

                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (soyNumero = false))
                                            {
                                                Console.WriteLine("Solo se adminten números enteros, intente nuevamente");
                                            }
                                        } while ((!soyNumero) && (precioMascota <= 0));

                                        if ((idMascota > 0) && (!string.IsNullOrEmpty(nombreMascota)) && (!string.IsNullOrEmpty(razaMascota)) && (edadMascota > 0) && (sexoMascota > 0) && (precioMascota > 0) && (!string.IsNullOrEmpty(rutComprador)) && (!string.IsNullOrEmpty(nombreComprador)))

                                        {

                                            mascota.Id = idMascota;
                                            mascota.NombreMascota = nombreMascota;
                                            mascota.Raza = razaMascota;
                                            mascota.Edad = edadMascota;
                                            mascota.Sexo = sexoMascota;
                                            mascota.PrecioVenta = precioMascota;
                                            mascota.NombreComprador = nombreComprador;
                                            mascota.RutComprador = rutComprador;

                                            string sexoMascotaString = "";

                                            Console.WriteLine("Los datos ingresados de la mascota N° <" + contadorCantidad + "> son los siguientes:");
                                            Console.WriteLine("Nombre del Comprador: <" + nombreComprador + ">");
                                            Console.WriteLine("Rut del Comprador: <" + rutComprador + ">");
                                            Console.WriteLine("ID Mascota: <" + idMascota + ">");
                                            Console.WriteLine("Nombre Mascota: <" + nombreMascota + ">");
                                            Console.WriteLine("Raza Mascota: <" + razaMascota + ">");
                                            Console.WriteLine("Edad Mascota: <" + edadMascota + ">");
                                            if (sexoMascota == 1)
                                            {
                                                sexoMascotaString = "MACHO";
                                            }
                                            else if (sexoMascota == 2)
                                            {
                                                sexoMascotaString = "HEMBRA";
                                            }
                                            Console.WriteLine("Sexo Mascota: <" + sexoMascota + ">, equivalente a : <" + sexoMascotaString + ">");
                                            Console.WriteLine("Valor Mascota: <" + precioMascota + ">");
                                            Console.WriteLine(" ");

                                            Console.ReadKey();


                                            valorVentaNeto = totalNeto.ValorVentaNeto(totalVentaMascotas, precioMascota);
                                            resta = restarCantidad.RestarDisponibles(cantidadDisponible, contadorCantidad);

                                            Console.WriteLine("Cantidad de mascotas vendidas hasta el momento: <" + contadorCantidad + ">");
                                            Console.WriteLine("Subtotal Neto Vendido: <$ " + valorVentaNeto + ">");
                                            Console.WriteLine("Cantidad Disponible para vender: <" + resta + ">");

                                            totalVentaMascotas = valorVentaNeto;
                                            contadorCantidad = contadorCantidad + 1;

                                        }

                                    }



                                } while ((contadorCantidad <= cantidadVenta) && (!terminarVenta.Equals("TERMINAR")));

                            }

                            if ((opcionRaza.Equals("SI") && opcionComprador.Equals("NO")) && ((tipoVenta == 0) || (tipoVenta == 2)))
                            {
                                tipoVenta = 2;

                                terminarVenta = "";

                                do
                                {
                                    Console.Write("Escriba la raza de las mascota: ");
                                    razaMascota = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(razaMascota))
                                    {
                                        Console.WriteLine("Debe ingresar al menos una raza, intente nuevamente");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Raza <" + razaMascota + "> Ingresada correctamente");
                                    }

                                } while (string.IsNullOrEmpty(razaMascota));

                                do
                                {

                                    Console.Write("Ingrese la ID numérica de la mascota N° <" + contadorCantidad + "> o escriba <TERMINAR> para finalizar: ");
                                    String tecladoUsuario = Console.ReadLine().Trim().ToUpper();
                                    Boolean soyNumero = false;

                                    if (int.TryParse(tecladoUsuario, out idMascota) && idMascota > 0)
                                    {
                                        Console.WriteLine("Hiciste lo correcto Bob");
                                        soyNumero = true;
                                    }
                                    else if (int.TryParse(tecladoUsuario, out idMascota) && idMascota <= 0)
                                    {
                                        Console.WriteLine("Sólo puede ingresar números mayores a 0, intente nuevamente");
                                    }
                                    else if (string.IsNullOrEmpty(tecladoUsuario))
                                    {
                                        Console.WriteLine("Debe ingresar un valor, intente nuevamente");
                                    }
                                    else if (tecladoUsuario.Equals("TERMINAR"))
                                    {

                                        do
                                        {
                                            Console.Write("Usted ha elegido terminar el proceso de venta, solo se guardarán los datos ingresados hasta ahora, para terminar escriba nuevamente <TERMINAR>, de lo contrario escriba <CONTINUAR>: ");
                                            terminarVenta = Console.ReadLine().Trim().ToUpper();
                                            if (terminarVenta.Equals("TERMINAR"))
                                            {
                                                Console.WriteLine("Se ha finalizado la venta actual");
                                            }
                                            else if (terminarVenta.Equals("CONTINUAR"))
                                            {
                                                Console.WriteLine("Usted ha elegido continuar la venta, siga ingresando los datos restantes");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opción ingresada no es válida, intente nuevamente");
                                            }

                                        } while (!terminarVenta.Equals("TERMINAR") && (!terminarVenta.Equals("CONTINUAR")));

                                    }
                                    else
                                    {
                                        Console.WriteLine("Opción ingresada no disponible, intente nuevamente");
                                    }


                                    if (idMascota > 0)
                                    {

                                        Console.WriteLine("La ID <" + idMascota + ">, de la mascota N° <" + contadorCantidad + ">, fue ingresada correctamente");

                                        do
                                        {
                                            Console.Write("Ingrese el RUT del Comprador de la mascota N° <" + contadorCantidad + ">");
                                            rutComprador = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(rutComprador))
                                            {
                                                Console.WriteLine("Debe ingresar al menos un RUT para el comprador, intente nuevamente");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El RUT <" + rutComprador + "> del comprador de la mascota N° <" + contadorCantidad + "> fue ingresado con éxito");
                                            }
                                        } while (string.IsNullOrWhiteSpace(rutComprador));

                                        do
                                        {
                                            Console.Write("Ingrese Nombre del Comprador para la mascota N° <" + contadorCantidad + ">");
                                            nombreComprador = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(nombreComprador))
                                            {
                                                Console.WriteLine("Debe ingresar al menos un Nombre para el comprador, intente nuevamente");
                                            }

                                        } while (string.IsNullOrWhiteSpace(nombreComprador));
                                        do
                                        {
                                            Console.Write("Ingrese el nombre de la mascota N° <" + contadorCantidad + ">: ");
                                            nombreMascota = Console.ReadLine();

                                            if (string.IsNullOrEmpty(nombreMascota))
                                            {
                                                Console.WriteLine("Debe ingresar un Nombre para la mascota");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El nombre <" + nombreMascota + ">, de la mascota N° <" + contadorCantidad + ">, se registrado exitosamente");
                                            }

                                        } while (string.IsNullOrEmpty(nombreMascota));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese Edad de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out edadMascota) && edadMascota > 0 && edadMascota < 30)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito la edad <" + edadMascota + "> para la mascota N° <" + contadorCantidad + ">");
                                                soyNumero = true;
                                            }
                                            else if (int.TryParse(tecladoUsuario, out edadMascota) && (edadMascota <= 0) || (edadMascota >= 30))
                                            {
                                                Console.WriteLine("Sólo puede ingresar una edad entre 1 y 29 años, intente nuevamente");
                                            }
                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((edadMascota <= 0) || (edadMascota >= 30) || (!soyNumero));
                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el sexo de la Mascota N° <" + contadorCantidad + ">. Digite <1> para Macho o <2> para Hembra: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out sexoMascota) && sexoMascota > 0 && sexoMascota < 3)
                                            {

                                                if (sexoMascota == 1)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }
                                                else if (sexoMascota == 2)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }

                                            }
                                            else if (int.TryParse(tecladoUsuario, out sexoMascota) && (sexoMascota != 1) || (sexoMascota != 2))
                                            {
                                                Console.WriteLine("Sólo puede ingresar las alternativas <1> para macho y <2> para hembra, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((sexoMascota != 1) && (sexoMascota != 2));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el Valor de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota > 0)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito el valor de la mascota N° <" + contadorCantidad + ">, por un monto de: " + precioMascota);
                                                precioMascota = int.Parse(tecladoUsuario);
                                                soyNumero = true;
                                            }

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota <= 0)
                                            {
                                                Console.WriteLine("Valor de la mascota no puede ser inferior ni igual a $0");

                                            }

                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (soyNumero = false))
                                            {
                                                Console.WriteLine("Solo se adminten números enteros, intente nuevamente");
                                            }
                                        } while ((!soyNumero) && (precioMascota <= 0));

                                        if ((idMascota > 0) && (!string.IsNullOrEmpty(nombreMascota)) && (!string.IsNullOrEmpty(razaMascota)) && (edadMascota > 0) && (sexoMascota > 0) && (precioMascota > 0) && (!string.IsNullOrEmpty(rutComprador)) && (!string.IsNullOrEmpty(nombreComprador)))

                                        {

                                            mascota.Id = idMascota;
                                            mascota.NombreMascota = nombreMascota;
                                            mascota.Raza = razaMascota;
                                            mascota.Edad = edadMascota;
                                            mascota.Sexo = sexoMascota;
                                            mascota.PrecioVenta = precioMascota;
                                            mascota.NombreComprador = nombreComprador;
                                            mascota.RutComprador = rutComprador;

                                            string sexoMascotaString = "";

                                            Console.WriteLine("Los datos ingresados de la mascota N° <" + contadorCantidad + "> son los siguientes:");
                                            Console.WriteLine("Nombre del Comprador: <" + nombreComprador + ">");
                                            Console.WriteLine("Rut del Comprador: <" + rutComprador + ">");
                                            Console.WriteLine("ID Mascota: <" + idMascota + ">");
                                            Console.WriteLine("Nombre Mascota: <" + nombreMascota + ">");
                                            Console.WriteLine("Raza Mascota: <" + razaMascota + ">");
                                            Console.WriteLine("Edad Mascota: <" + edadMascota + ">");
                                            if (sexoMascota == 1)
                                            {
                                                sexoMascotaString = "MACHO";
                                            }
                                            else if (sexoMascota == 2)
                                            {
                                                sexoMascotaString = "HEMBRA";
                                            }
                                            Console.WriteLine("Sexo Mascota: <" + sexoMascota + ">, equivalente a : <" + sexoMascotaString + ">");
                                            Console.WriteLine("Valor Mascota: <" + precioMascota + ">");
                                            Console.WriteLine(" ");
                                            Console.ReadKey();


                                            valorVentaNeto = totalNeto.ValorVentaNeto(totalVentaMascotas, precioMascota);

                                            resta = restarCantidad.RestarDisponibles(cantidadDisponible, contadorCantidad);

                                            Console.WriteLine("Cantidad de mascotas vendidas hasta el momento: <" + contadorCantidad + ">");
                                            Console.WriteLine("Subtotal Neto Vendido: <$ " + valorVentaNeto + ">");
                                            Console.WriteLine("Cantidad Disponible para vender: <" + resta + ">");

                                            totalVentaMascotas = valorVentaNeto;
                                            contadorCantidad = contadorCantidad + 1;

                                        }

                                    }


                                } while ((contadorCantidad <= cantidadVenta) && (!terminarVenta.Equals("TERMINAR")));

                            }

                            if ((opcionRaza.Equals("NO") && opcionComprador.Equals("SI")) && ((tipoVenta == 0) || (tipoVenta == 3)))
                            {
                                tipoVenta = 3;

                                terminarVenta = "";

                                do
                                {
                                    Console.Write("Ingrese el RUT del Comprador: ");
                                    rutComprador = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(rutComprador))
                                    {
                                        Console.WriteLine("Debe ingresar al menos un RUT para el comprador, intente nuevamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Rut Comprador <" + rutComprador + "> Ingresado correctamente");
                                    }
                                } while (string.IsNullOrWhiteSpace(rutComprador));
                                do
                                {
                                    Console.Write("Ingrese Nombre del Comprador: ");
                                    nombreComprador = Console.ReadLine().Trim().ToUpper();
                                    if (string.IsNullOrEmpty(nombreComprador))
                                    {
                                        Console.WriteLine("Debe ingresar al menos un Nombre para el comprador, intente nuevamente");
                                    }
                                    {
                                        Console.WriteLine("Nombre del Comprador <" + nombreComprador + "> Ingresado correctamente");
                                    }
                                } while (string.IsNullOrWhiteSpace(nombreComprador));

                                do
                                {

                                    Console.Write("Ingrese la ID numérica de la mascota N° <" + contadorCantidad + "> o escriba <TERMINAR> para finalizar: ");
                                    String tecladoUsuario = Console.ReadLine().Trim().ToUpper();
                                    Boolean soyNumero = false;

                                    if (int.TryParse(tecladoUsuario, out idMascota) && idMascota > 0)
                                    {
                                        Console.WriteLine("Hiciste lo correcto Bob");
                                        soyNumero = true;
                                    }
                                    else if (int.TryParse(tecladoUsuario, out idMascota) && idMascota <= 0)
                                    {
                                        Console.WriteLine("Sólo puede ingresar números mayores a 0, intente nuevamente");
                                    }
                                    else if (string.IsNullOrEmpty(tecladoUsuario))
                                    {
                                        Console.WriteLine("Debe ingresar un valor, intente nuevamente");
                                    }
                                    else if (tecladoUsuario.Equals("TERMINAR"))
                                    {

                                        do
                                        {
                                            Console.Write("Usted ha elegido terminar el proceso de venta, solo se guardarán los datos ingresados hasta ahora, para terminar escriba nuevamente <TERMINAR>, de lo contrario escriba <CONTINUAR>: ");
                                            terminarVenta = Console.ReadLine().Trim().ToUpper();
                                            if (terminarVenta.Equals("TERMINAR"))
                                            {
                                                Console.WriteLine("Se ha finalizado la venta actual");
                                            }
                                            else if (terminarVenta.Equals("CONTINUAR"))
                                            {
                                                Console.WriteLine("Usted ha elegido continuar la venta, siga ingresando los datos restantes");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opción ingresada no es válida, intente nuevamente");
                                            }

                                        } while (!terminarVenta.Equals("TERMINAR") && (!terminarVenta.Equals("CONTINUAR")));

                                    }
                                    else
                                    {
                                        Console.WriteLine("Opción ingresada no disponible, intente nuevamente");
                                    }


                                    if (idMascota > 0)
                                    {

                                        Console.WriteLine("La ID <" + idMascota + ">, de la mascota N° <" + contadorCantidad + ">, fue ingresada correctamente");
                                        do
                                        {
                                            Console.Write("Escriba la raza de la mascota N° <" + contadorCantidad + ">: ");
                                            razaMascota = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(razaMascota))
                                            {
                                                Console.WriteLine("Debe ingresar al menos una raza, intente nuevamente");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Raza <" + razaMascota + "> >Ingresada correctamente en mascota N° < " + contadorCantidad + ">");
                                            }
                                        } while (string.IsNullOrEmpty(razaMascota));

                                        do
                                        {
                                            Console.Write("Ingrese el nombre de la mascota N° <" + contadorCantidad + ">: ");
                                            nombreMascota = Console.ReadLine();

                                            if (string.IsNullOrEmpty(nombreMascota))
                                            {
                                                Console.WriteLine("Debe ingresar un Nombre para la mascota");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El nombre <" + nombreMascota + ">, de la mascota N° <" + contadorCantidad + ">, se registrado exitosamente");
                                            }

                                        } while (string.IsNullOrEmpty(nombreMascota));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese Edad de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out edadMascota) && edadMascota > 0 && edadMascota < 30)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito la edad <" + edadMascota + "> para la mascota N° <" + contadorCantidad + ">");
                                                soyNumero = true;
                                            }
                                            else if (int.TryParse(tecladoUsuario, out edadMascota) && (edadMascota <= 0) || (edadMascota >= 30))
                                            {
                                                Console.WriteLine("Sólo puede ingresar una edad entre 1 y 29 años, intente nuevamente");
                                            }
                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((edadMascota <= 0) || (edadMascota >= 30) || (!soyNumero));
                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el sexo de la Mascota N° <" + contadorCantidad + ">. Digite <1> para Macho o <2> para Hembra: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out sexoMascota) && sexoMascota > 0 && sexoMascota < 3)
                                            {

                                                if (sexoMascota == 1)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }
                                                else if (sexoMascota == 2)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }

                                            }
                                            else if (int.TryParse(tecladoUsuario, out sexoMascota) && (sexoMascota != 1) || (sexoMascota != 2))
                                            {
                                                Console.WriteLine("Sólo puede ingresar las alternativas <1> para macho y <2> para hembra, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((sexoMascota != 1) && (sexoMascota != 2));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el Valor de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota > 0)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito el valor de la mascota N° <" + contadorCantidad + ">, por un monto de: " + precioMascota);
                                                precioMascota = int.Parse(tecladoUsuario);
                                                soyNumero = true;
                                            }

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota <= 0)
                                            {
                                                Console.WriteLine("Valor de la mascota no puede ser inferior ni igual a $0");

                                            }

                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (soyNumero = false))
                                            {
                                                Console.WriteLine("Solo se adminten números enteros, intente nuevamente");
                                            }
                                        } while ((!soyNumero) && (precioMascota <= 0));

                                        if ((idMascota > 0) && (!string.IsNullOrEmpty(nombreMascota)) && (!string.IsNullOrEmpty(razaMascota)) && (edadMascota > 0) && (sexoMascota > 0) && (precioMascota > 0) && (!string.IsNullOrEmpty(rutComprador)) && (!string.IsNullOrEmpty(nombreComprador)))

                                        {

                                            mascota.Id = idMascota;
                                            mascota.NombreMascota = nombreMascota;
                                            mascota.Raza = razaMascota;
                                            mascota.Edad = edadMascota;
                                            mascota.Sexo = sexoMascota;
                                            mascota.PrecioVenta = precioMascota;
                                            mascota.NombreComprador = nombreComprador;
                                            mascota.RutComprador = rutComprador;

                                            string sexoMascotaString = "";

                                            Console.WriteLine("Los datos ingresados de la mascota N° <" + contadorCantidad + "> son los siguientes:");
                                            Console.WriteLine("Nombre del Comprador: <" + nombreComprador + ">");
                                            Console.WriteLine("Rut del Comprador: <" + rutComprador + ">");
                                            Console.WriteLine("ID Mascota: <" + idMascota + ">");
                                            Console.WriteLine("Nombre Mascota: <" + nombreMascota + ">");
                                            Console.WriteLine("Raza Mascota: <" + razaMascota + ">");
                                            Console.WriteLine("Edad Mascota: <" + edadMascota + ">");
                                            if (sexoMascota == 1)
                                            {
                                                sexoMascotaString = "MACHO";
                                            }
                                            else if (sexoMascota == 2)
                                            {
                                                sexoMascotaString = "HEMBRA";
                                            }
                                            Console.WriteLine("Sexo Mascota: <" + sexoMascota + ">, equivalente a : <" + sexoMascotaString + ">");
                                            Console.WriteLine("Valor Mascota: <" + precioMascota + ">");
                                            Console.WriteLine(" ");
                                            Console.ReadKey();


                                            valorVentaNeto = totalNeto.ValorVentaNeto(totalVentaMascotas, precioMascota);

                                            resta = restarCantidad.RestarDisponibles(cantidadDisponible, contadorCantidad);

                                            Console.WriteLine("Cantidad de mascotas vendidas hasta el momento: <" + contadorCantidad + ">");
                                            Console.WriteLine("Subtotal Neto Vendido: <$ " + valorVentaNeto + ">");
                                            Console.WriteLine("Cantidad Disponible para vender: <" + resta + ">");

                                            totalVentaMascotas = valorVentaNeto;
                                            contadorCantidad = contadorCantidad + 1;

                                        }

                                    }


                                } while ((contadorCantidad <= cantidadVenta) && (!terminarVenta.Equals("TERMINAR")));

                            }


                            if ((opcionRaza.Equals("NO") && opcionComprador.Equals("NO")) && ((tipoVenta == 0) || (tipoVenta == 4)))
                            {
                                tipoVenta = 4;
                                terminarVenta = "";

                                do
                                {

                                    Console.Write("Ingrese la ID numérica de la mascota N° <" + contadorCantidad + "> o escriba <TERMINAR> para finalizar: ");
                                    String tecladoUsuario = Console.ReadLine().Trim().ToUpper();
                                    Boolean soyNumero = false;

                                    if (int.TryParse(tecladoUsuario, out idMascota) && idMascota > 0)
                                    {
                                        Console.WriteLine("Hiciste lo correcto Bob");
                                        soyNumero = true;
                                    }
                                    else if (int.TryParse(tecladoUsuario, out idMascota) && idMascota <= 0)
                                    {
                                        Console.WriteLine("Sólo puede ingresar números mayores a 0, intente nuevamente");
                                    }
                                    else if (string.IsNullOrEmpty(tecladoUsuario))
                                    {
                                        Console.WriteLine("Debe ingresar un valor, intente nuevamente");
                                    }
                                    else if (tecladoUsuario.Equals("TERMINAR"))
                                    {

                                        do
                                        {
                                            Console.Write("Usted ha elegido terminar el proceso de venta, solo se guardarán los datos ingresados hasta ahora, para terminar escriba nuevamente <TERMINAR>, de lo contrario escriba <CONTINUAR>: ");
                                            terminarVenta = Console.ReadLine().Trim().ToUpper();
                                            if (terminarVenta.Equals("TERMINAR"))
                                            {
                                                Console.WriteLine("Se ha finalizado la venta actual");
                                            }
                                            else if (terminarVenta.Equals("CONTINUAR"))
                                            {
                                                Console.WriteLine("Usted ha elegido continuar la venta, siga ingresando los datos restantes");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opción ingresada no es válida, intente nuevamente");
                                            }

                                        } while (!terminarVenta.Equals("TERMINAR") && (!terminarVenta.Equals("CONTINUAR")));

                                    }
                                    else
                                    {
                                        Console.WriteLine("Opción ingresada no disponible, intente nuevamente");
                                    }


                                    if (idMascota > 0)
                                    {

                                        Console.WriteLine("La ID <" + idMascota + ">, de la mascota N° <" + contadorCantidad + ">, fue ingresada correctamente");

                                        do
                                        {
                                            Console.Write("Ingrese el RUT del Comprador de la mascota N° <" + contadorCantidad + "> :");
                                            rutComprador = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(rutComprador))
                                            {
                                                Console.WriteLine("Debe ingresar al menos un RUT para el comprador, intente nuevamente");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El RUT <" + rutComprador + "> del comprador de la mascota N° <" + contadorCantidad + "> fue ingresado con éxito");
                                            }
                                        } while (string.IsNullOrWhiteSpace(rutComprador));

                                        do
                                        {
                                            Console.Write("Ingrese Nombre del Comprador para la mascota N° <" + contadorCantidad + ">: ");
                                            nombreComprador = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(nombreComprador))
                                            {
                                                Console.WriteLine("Debe ingresar al menos un Nombre para el comprador, intente nuevamente");
                                            }

                                        } while (string.IsNullOrWhiteSpace(nombreComprador));

                                        do
                                        {
                                            Console.Write("Escriba la raza de las mascota N° <" + contadorCantidad + ">: ");
                                            razaMascota = Console.ReadLine().Trim().ToUpper();
                                            if (string.IsNullOrEmpty(razaMascota))
                                            {
                                                Console.WriteLine("Debe ingresar al menos una raza, intente nuevamente");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Raza <" + razaMascota + "> >Ingresada correctamente en mascota N° < " + contadorCantidad + ">");
                                            }
                                        } while (string.IsNullOrEmpty(razaMascota));

                                        do
                                        {
                                            Console.Write("Ingrese el nombre de la mascota N° <" + contadorCantidad + ">: ");
                                            nombreMascota = Console.ReadLine();

                                            if (string.IsNullOrEmpty(nombreMascota))
                                            {
                                                Console.WriteLine("Debe ingresar un Nombre para la mascota");
                                            }
                                            else
                                            {
                                                Console.WriteLine("El nombre <" + nombreMascota + ">, de la mascota N° <" + contadorCantidad + ">, se registrado exitosamente");
                                            }

                                        } while (string.IsNullOrEmpty(nombreMascota));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese Edad de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out edadMascota) && edadMascota > 0 && edadMascota < 30)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito la edad <" + edadMascota + "> para la mascota N° <" + contadorCantidad + ">");
                                                soyNumero = true;
                                            }
                                            else if (int.TryParse(tecladoUsuario, out edadMascota) && (edadMascota <= 0) || (edadMascota >= 30))
                                            {
                                                Console.WriteLine("Sólo puede ingresar una edad entre 1 y 29 años, intente nuevamente");
                                            }
                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((edadMascota <= 0) || (edadMascota >= 30) || (!soyNumero));
                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el sexo de la Mascota N° <" + contadorCantidad + ">. Digite <1> para Macho o <2> para Hembra: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out sexoMascota) && sexoMascota > 0 && sexoMascota < 3)
                                            {

                                                if (sexoMascota == 1)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }
                                                else if (sexoMascota == 2)
                                                {
                                                    Console.WriteLine("Se ha ingresado con éxito el sexo de la mascota <" + contadorCantidad + "> como Macho según opción ingresada N° " + sexoMascota);
                                                    sexoMascota = int.Parse(tecladoUsuario);
                                                    soyNumero = true;
                                                }

                                            }
                                            else if (int.TryParse(tecladoUsuario, out sexoMascota) && (sexoMascota != 1) || (sexoMascota != 2))
                                            {
                                                Console.WriteLine("Sólo puede ingresar las alternativas <1> para macho y <2> para hembra, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (!soyNumero))
                                            {
                                                Console.WriteLine("Campo debe ser numérico, intente nuevamente");
                                            }

                                        } while ((sexoMascota != 1) && (sexoMascota != 2));

                                        do
                                        {
                                            soyNumero = false;

                                            Console.Write("Ingrese el Valor de la Mascota N° <" + contadorCantidad + ">: ");
                                            tecladoUsuario = Console.ReadLine().Trim().ToUpper();

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota > 0)
                                            {
                                                Console.WriteLine("Se ha ingresado con éxito el valor de la mascota N° <" + contadorCantidad + ">, por un monto de: " + precioMascota);
                                                precioMascota = int.Parse(tecladoUsuario);
                                                soyNumero = true;
                                            }

                                            if (int.TryParse(tecladoUsuario, out precioMascota) && precioMascota <= 0)
                                            {
                                                Console.WriteLine("Valor de la mascota no puede ser inferior ni igual a $0");

                                            }

                                            else if (string.IsNullOrEmpty(tecladoUsuario))
                                            {
                                                Console.WriteLine("Campo no puede estar vacío, intente nuevamente");
                                            }
                                            else if (!string.IsNullOrEmpty(tecladoUsuario) && (soyNumero = false))
                                            {
                                                Console.WriteLine("Solo se adminten números enteros, intente nuevamente");
                                            }
                                        } while ((!soyNumero) && (precioMascota <= 0));

                                        if ((idMascota > 0) && (!string.IsNullOrEmpty(nombreMascota)) && (!string.IsNullOrEmpty(razaMascota)) && (edadMascota > 0) && (sexoMascota > 0) && (precioMascota > 0) && (!string.IsNullOrEmpty(rutComprador)) && (!string.IsNullOrEmpty(nombreComprador)))

                                        {


                                            string sexoMascotaString = "";

                                            Console.WriteLine("Los datos ingresados de la mascota N° <" + contadorCantidad + "> son los siguientes:");
                                            Console.WriteLine("Nombre del Comprador: <" + nombreComprador + ">");
                                            Console.WriteLine("Rut del Comprador: <" + rutComprador + ">");
                                            Console.WriteLine("ID Mascota: <" + idMascota + ">");
                                            Console.WriteLine("Nombre Mascota: <" + nombreMascota + ">");
                                            Console.WriteLine("Raza Mascota: <" + razaMascota + ">");
                                            Console.WriteLine("Edad Mascota: <" + edadMascota + ">");
                                            if (sexoMascota == 1)
                                            {
                                                sexoMascotaString = "MACHO";
                                            }
                                            else if (sexoMascota == 2)
                                            {
                                                sexoMascotaString = "HEMBRA";
                                            }
                                            Console.WriteLine("Sexo Mascota: <" + sexoMascota + ">, equivalente a : <" + sexoMascotaString + ">");
                                            Console.WriteLine("Valor Mascota: <" + precioMascota + ">");
                                            Console.WriteLine(" ");
                                            Console.ReadKey();

                                            valorVentaNeto = totalNeto.ValorVentaNeto(totalVentaMascotas, precioMascota);
                                            resta = restarCantidad.RestarDisponibles(cantidadDisponible, contadorCantidad);


                                            Console.WriteLine("Cantidad de mascotas vendidas hasta el momento: <" + contadorCantidad + ">");
                                            Console.WriteLine("Subtotal Neto Vendido: <$ " + valorVentaNeto + ">");
                                            Console.WriteLine("Cantidad Disponible para vender: <" + resta + ">");

                                            totalVentaMascotas = valorVentaNeto;
                                            contadorCantidad = contadorCantidad + 1;

                                        }

                                    }


                                } while ((contadorCantidad <= cantidadVenta) && (!terminarVenta.Equals("TERMINAR")));

                            }

                            if (valorVentaNeto > 0)
                            {

                                montoDescuento = descuento.Descuento(valorVentaNeto);
                                valorVenta = valorV.ValorVenta(valorVentaNeto, (int)montoDescuento);
                                porcentajeDescto = porcDescuento.PorcentajeDescuento(valorVentaNeto);
                                valorIva = iva.MontoIva(valorVenta);
                                totalVenta = totalV.TotalVenta(valorVenta, valorIva);

                                Console.WriteLine("Valor Venta Neto : <" + valorVentaNeto + ">");
                                Console.WriteLine("Porcentaje de Descuento: <" + porcentajeDescto + ">");
                                Console.WriteLine("Monto del Descuento: <" + montoDescuento + ">");
                                Console.WriteLine("Valor de la Venta : <" + valorVenta + ">");
                                Console.WriteLine("Valor del Iva (19%) : <" + valorIva + ">");
                                Console.WriteLine("Total Venta : <" + totalVenta + ">");

                            }

                        }

                    }

                    if (resta > 0 && terminarVenta.Equals("TERMINAR"))
                    {
                        do
                        {
                            Console.WriteLine("Aún tiene <" + resta + "> Mascotas disponibles para vender, para salir de la venta escriba <SALIR>, esto eliminará todas las mascotas disponibles y deberá comenzar todo el proceso de nuevo, si desea continuar vendiendo, escriba <CONTINUAR>: ");
                            opcion = Console.ReadLine().Trim().ToUpper();

                            if ((!opcion.Equals("SALIR")) && (!opcion.Equals("CONTINUAR")))
                            {
                                Console.WriteLine("Opción inválida, por favor intente nuevamente");
                            }
                            if (opcion.Equals("CONTINUAR"))
                            {
                                Console.WriteLine("Usted ha elegido la opción <CONTINUAR>, para seguir vendiendo siga ingresando los datos solicitados");
                            }

                        } while ((!opcion.Equals("SALIR")) && (!opcion.Equals("CONTINUAR")));
                    }

                    if (opcion.Equals("SALIR"))
                    {
                        Console.WriteLine("Usted ha salido de la venta");
                    }

                    Console.ReadKey();

                } while (!opcion.Equals("SALIR") && (resta > 0));
            }

            Console.WriteLine("Usted ha salido de la venta o ha superado la cantidad disponible, gracias por operar con nosotros");

            Console.ReadKey();
        }
    }
}
