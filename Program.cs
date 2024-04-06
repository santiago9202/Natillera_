using System.Net;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args) //PASCAL 
    {
        /*Realizar un algoritmo en C# para una Natillera Navideña que determina cuánto ahorrará una persona en el año 2024, si al final de cada mes deposita cantidades variables de dinero; además, calcular los rendimientos generados por el ahorro en cada mes, correspondientes a la tasa del momento estipulada por Banco De La República (Tasas generadas por la clase Random entre 0.1% y 5.0%). Si la tasa del mes es inferior al 1.5%, entonces la Natillera estará en capacidad de otorgarle un bono a esa persona correspondiente a 2/5 partes del ahorro de dicho mes.  

        Se quiere saber cuál fue la tasa estipulada por el Banco de La República, cuánto lleva ahorrado, cuánto se otorgó de bono (si aplica) y cuánto lleva de rendimiento en cada mes, además se quiere saber el ahorro total, el bono total, los rendimientos totales al cabo de un año, y la suma total neta que se le consignará a esa persona.

        La aplicación debe tener la funcionalidad de preguntar al usuario si quiere volver al inicio para determinar el ahorro y rendimientos del siguiente año. Si no, salirse del programa. */

        //Variables
        bool volver = true;
        const double BONO = 0.4; //Snake Case:Notación para constantes.
        const decimal MULTA = 20000M;
        const decimal INTERES_PRESTAMO = 0.025M;

        while (volver)
        {
            decimal aporteMensual1, aporteMensual2, rendimientoMensual1, rendimientoMensual2, aporteTotal1 = 0, aporteTotal2 = 0,
               rendimientoTotal1 = 0, rendimientoTotal2 = 0, bonoMensual1 = 0, bonoMensual2 = 0, bonoTotal1 = 0, bonoTotal2 = 0,
                    aporteTotalNeto1, aporteTotalNeto2, tasaMensual1, tasaMensual2;
            string continuar;

            //Clase random
            Random random = new Random(); //Esta es la forma de instanciar una clase en objeto

            for (int mes = 1; mes <= 12; mes++)
            {
                //socio_1
                Console.Write($"Ingrese la cantidad que desea ahorrar en el mes {mes}: ");
                aporteMensual1 = Convert.ToDecimal(Console.ReadLine());


                //socio_2
                Console.Write($"Ingrese la cantidad que desea ahorrar en el mes {mes}: ");
                aporteMensual2 = Convert.ToDecimal(Console.ReadLine());

                //Tasa mensual para ambos socios

                tasaMensual1 = (decimal)random.Next(1, 51) / 10;
                tasaMensual2 = (decimal)random.Next(1, 51) / 10;

                //Rendimientos mensuales para ambos
                rendimientoMensual1 = aporteMensual1 * (tasaMensual1 / 100);
                rendimientoMensual2 = aporteMensual2 * (tasaMensual2 / 100);


                if (tasaMensual1 < 1.5M) //bomo primer socio
                {
                    bonoMensual1 = aporteMensual1 * (decimal)BONO;
                    bonoTotal1 += bonoMensual1;
                    bonoMensual1 = 0;
                }

                if (tasaMensual2 < 1.5M) //bono segundo socio
                {
                    bonoMensual2 = aporteMensual2 * (decimal)BONO;
                    bonoTotal2 += bonoMensual2;
                    bonoMensual2 = 0;
                }
                if (aporteMensual1 == 0) 
                {
                    aporteMensual1 -= MULTA;
                }
                if (aporteMensual2 == 0) 
                {
                    aporteMensual2 -= MULTA;
                }

                aporteTotal1 += aporteMensual1;
                aporteTotal2 += aporteMensual2;
                rendimientoTotal1 += rendimientoMensual1;
                rendimientoTotal2 += rendimientoMensual2;

                Console.WriteLine($"MES {mes}\n" +
                                     $"Socio 1:\n" +
                                     $"Aporte: {aporteMensual1:C}\n" +
                                     $"Tasa: {tasaMensual1}%\n" +
                                     $"Rendimientos: {rendimientoMensual1:C}\n" +
                                     $"Bono: {bonoMensual1:C}\n" +
                                     $"Socio 2:\n" +
                                     $"Aporte: {aporteMensual2:C}\n" +
                                     $"Tasa: {tasaMensual2}%\n" +
                                     $"Rendimientos: {rendimientoMensual2:C}\n" +
                                     $"Bono: {bonoMensual2:C}\n" +
                                     $"---------------------------------------\n");
            }

            // Calculo de totales netos
            aporteTotalNeto1 = rendimientoTotal1 + aporteTotal1 + bonoTotal1;
            aporteTotalNeto2 = rendimientoTotal2 + aporteTotal2 + bonoTotal2;

            Console.WriteLine($"Socio 1:\n" +
                              $"Aporte total: {aporteTotal1:C}\n" +
                              $"Rendimientos totales: {rendimientoTotal1:C}\n" +
                              $"Bonos totales: {bonoTotal1:C}\n" +
                              $"--------------------------------\n" +
                              $"TOTAL NETO: {aporteTotalNeto1:C}\n\n" +
                              $"Socio 2:\n" +
                              $"Aporte total: {aporteTotal2:C}\n" +
                              $"Rendimientos totales: {rendimientoTotal2:C}\n" +
                              $"Bonos totales: {bonoTotal2:C}\n" +
                              $"--------------------------------\n" +
                              $"TOTAL NETO: {aporteTotalNeto2:C}\n\n");

            // Preguntar si desea continuar
            Console.WriteLine("¿Desea ingresar a la natillera para el siguiente año? (s/n)");
            continuar = Console.ReadLine().ToLower();
            if (continuar == "n") volver = false;
        }

        
    }
}