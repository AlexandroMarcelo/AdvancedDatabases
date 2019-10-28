#include <iostream>
#include <fstream>
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
#include <string>
using namespace std;

int main()
{
	ofstream file;
	srand (time(NULL));
	int randDia, randMes, randAno, inicio, final, inicioFor, finalFor, randRelacion, randD, randM, randA;
	string dia, mes, d, m;
	//file.open("conoce_a.csv");
	//file.open("amigo_de.csv");
	file.open("pareja_de.csv");
	inicio = rand() % 30;
	final =  rand() % 30 + 70;
	//int N = 100;

	file << "StartId,EndId,inicioRelacion,finRelacion" << endl;
	for(int i = inicio; i < final; i++)
	{
		//inicioFor = rand() % 40;
		//finalFor = rand() % 40 + 60;
		inicioFor = rand() % 5;
		finalFor = rand() % 40 + 60;
		//for (int j = inicioFor; j < finalFor; j++)
		for (int j = 0; j < inicioFor; j++)
		{
			randRelacion = rand() % 100;
			if (i != j)
			{
				randAno = rand() % 5 + 2010;
				randMes = rand() % 11 + 1;
				randDia = rand() % 27 +1;
				dia = to_string(randDia);
				mes = to_string(randMes);
				if (randDia < 10)
				{
					dia = "0"+to_string(randDia); 
				}
				if (randMes < 10)
				{
					mes = "0"+to_string(randMes); 
				}
				randA = rand() % 4 + 2015;
				randM = rand() % 11 + 1;
				randD = rand() % 27 +1;
				d = to_string(randD);
				m = to_string(randM);
				if (randD < 10)
				{
					d = "0"+to_string(randD); 
				}
				if (randM < 10)
				{
					m = "0"+to_string(randM); 
				}
				file << i << "," << randRelacion << "," << randAno << "-" << mes << "-" << dia << "," << randA << "-" << m << "-" << d << endl;
			}
		}
	}
	file.close();
	return 0;
}