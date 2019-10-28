#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ofstream file;
	file.open("data.txt");
	int N = 1000000;

	for(int i = 0; i < N; i++)
	{
		file << "SET {KEY}" << i << " " << i << endl;
	}

	return 0;
}