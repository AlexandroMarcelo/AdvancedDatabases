#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ofstream file;
	file.open("data.txt");
	int N = 3000000;

	for(int i = 0; i < N; i++)
	{
		file << "set " << i << " " << i << "\n";
	}

	file.close();
	return 0;
}