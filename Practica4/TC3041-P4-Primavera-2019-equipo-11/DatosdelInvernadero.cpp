//Andrés Campos Tams - A01024385

#include<iostream>
#include<fstream>
#include<cmath>
#include<string>
#include<random>
#include<time.h>

using namespace std;

//The main program
int main(int argc, char **argv)
{
	srand(time(NULL));
	ofstream A;
	A.open("DatosInvernadero.txt");
	A<<"# DDL\n\nCREATE DATABASE Invernaderos\n\n# DML\n\n# CONTEXT-DATABASE: Invernaderos\n";
	//Humedad
	for(unsigned long int i=0;i<7;i++)
	{
		int prct = rand()%100;
		for(unsigned long int j=0;j<1000000;j++)
		{
		A<<"Humedad,Numero_Invernadero="<<i+1<<" Nivel_de_humedad=";
		prct+=(rand()%3) - 1;
		if(prct > 90)
		prct = 90;
		if(prct < 30)
		prct = 30;
		A<<prct;
		A<<" ";
		A<<1556496000+j*60;
		A<<"\n";
		}
	}
	//Temperatura
	for(unsigned long int i=0;i<7;i++)
	{
		int prct = rand()%100;
		for(unsigned long int j=0;j<1000000;j++)
		{
		A<<"Temperatura,Numero_Invernadero="<<i+1<<" Temperatura=";
		prct+=(rand()%3) - 1;
		if(prct > 35)
		prct = 35;
		if(prct < 20)
		prct = 20;
		A<<prct;
		A<<" ";
		A<<1556496000+j*60;
		A<<"\n";
		}
	}
	//Luminosidad
	for(unsigned long int i=0;i<7;i++)
	{
		int prct = rand()%100;
		for(unsigned long int j=0;j<1000000;j++)
		{
		A<<"Luminosidad,Numero_Invernadero="<<i+1<<" Porcentaje_de_Luminosidad=";
		if(j%500==0)
		prct+=(rand()%3) - 1;
		if(prct > 100)
		prct = 100;
		if(prct < 10)
		prct = 10;
		A<<prct;
		A<<" ";
		A<<1556496000+j*60;
		A<<"\n";
		}
	}
	A.close();
    return 0;
}
