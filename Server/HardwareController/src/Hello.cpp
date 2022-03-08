#include <iostream>

extern "C"
{
	const char* GetHello()
	{
		return "Hello World from C/C++!";
	}

	void PrintHello()
	{
		std::cout << "Hello world from C/C++!" << std::endl;
	}
}
