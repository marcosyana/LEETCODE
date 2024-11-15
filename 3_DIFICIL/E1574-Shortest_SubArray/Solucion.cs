//1574. Shortest Subarray to be Removed to Make Array Sorted
//1574. Submatriz más corta que se debe eliminar para ordenar la matriz
/*
Example 1:

Entrada: matriz = [1,2,3,10,4,2,3,5]
Salida: 3
Explicacion: El sub arreglo mas corto que podemos eliminar es [10,4,2] de longitud 3. 
los elementos restantes despues de eso seran [1,2,3,3,5] que estan ordenados.
Otra solucion correcta es eliminar el subArreglo [3,10,4]. 
 */

using System;

public class Solucion
{
    public int BusquedaSubArray (int[] matriz)
    {
        int n = matriz.Length; //Asignamos la longitud del arreglo
        int i = 0, j = n - 1;
        //Bucle q se encarga de ver si es creciente el arreglo desde inicio
        while (i + 1 < n && matriz[i] <= matriz[i+1])
        {
            i++;
        }
        //Bucle q se encarga de ver si es creciente el arreglo desde el final
        while (j-1>=0 && matriz[j-1]<= matriz[j])
        {
            j--;
        }
        //Verificamos si el arreglo es creciente en su totalidad
        if (i >= j)
        {
            return 0;
        }
        //Calculamos el valor minimo, elimina desde el indice al final y j desde el inicio al indice
        int valorMinimo = Math.Min(n - i - 1, j);
        // conbinamos segmentos, itera desde el inicio hasta i
        for (int l = 0; l <= i; l++)
        {
            int indiceMinimo = Busqueda(matriz, matriz[l], j);
            valorMinimo = Math.Min(valorMinimo, indiceMinimo - l - 1);
        }
        return valorMinimo;
    }

    //Metodo para hacer busquedas binarias leth = punto de inicio para la busqueda, right = almacena la longitud del arreglo
    private int Busqueda(int[] matriz, int x, int left)
    {
        int right = matriz.Length;//almacenamos la logitud de la matriz 
        //hacemos una busqueda binaria
        while (left < right)
        {
            int valorMedio = (left + right) / 2;
            if (matriz[valorMedio] >= x)
            {
                right = valorMedio;
            }
            else
            {
                left = valorMedio + 1;
            }
        }
        return left;
    }

    public static void Main(string[] args)
    {
        // Creamos una instancia
        Solucion solution = new Solucion();

        // Prueba el método con un ejemplo
        int[] arr = { 1, 2, 3 };
        int result = solution.BusquedaSubArray(arr);
        Console.WriteLine("El resultado es: " + result);
    }
}