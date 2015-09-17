#include <stdlib.h>
#include <time.h>
#include <string.h>

#define EXPORT __declspec(dllexport)

extern "C" {
	//int EXPORT randomNumber();
	//void EXPORT setSeed();
	//const char EXPORT *question(int num1, int num2, char mode);
	int EXPORT question(void);
}

//int EXPORT randomNumber() {
//	return rand()%100;
//}
//
//void EXPORT setSeed() {
//	srand(time(NULL));
//}
//
//const char EXPORT *question(int num1, int num2, char mode) {
//	char buffer[6];
//	int index = 0;
//	
//	buffer[index] = '0' + num1/10;
//	if(num1 >= 10)
//		index++;
//	buffer[index++] = '0' + num1%10;
//	buffer[index++] = (mode=='p')?'+':'X';
//	buffer[index] = '0' + num2/10;
//	if(num2 >= 10)
//		index++;
//	buffer[index++] = '0' + num2%10;
//	buffer[index] = '\0';
//
//	return buffer;
//}

int EXPORT question(void) {
	srand(time(NULL));
	
	int num1 = rand()%99 + 1;
	int num2 = rand()%99 + 1;
	int op = rand()%2;

	int result = num1*1000 + num2*10 + op;

	return result;
}