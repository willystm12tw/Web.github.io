#include <stdio.h>
#include <time.h>

int main (void) {
    srand((unsigned)time(0));
    int i,j;
    int A= 0;
    int B= 0;
    int arr[4];
    int Guess[4];
    int Number;
    int End;
    int Again;
    printf("Game rule: Enter four numbers and game will tell you A and B\n");
    printf("A is correct position and number, B is wrong position and correct number.\n");
    printf("If answer is 1234, And you guess is 4321, A = 0, B = 4\n");
    printf("If answer is 1234, And you guess is 1243, A = 2, B = 2\n");
    printf("Now start!\n\n");

start:
    // int Rand0,Rand1,Rand2,Rand3;
        //printf("Answer is");
   for(i = 1; i <= 4; i++) {
            do{
        arr[i-1]=rand() % 9;
        for (j=1; j < i;j++){
            if(arr[i-1] == arr[j-1]){
                break;
                    }
                }
            } while(j != i);
        //printf("%d",arr[i-1]);
    }

do{
End=0;
printf("You Guess is :");
    scanf(" %d", &Number);

    do{
        if(Number-10000>=0){
            printf("Hey You enter wrong numbers!!!\n");
            End=1;
              break;
        }
  /*/            else if(Number-1000<=0)
                {
                End=1;
              printf("Hey You enter wrong numbers!!!\n");
              break;
              }
  /*/            else{
                End=0;
                   }

        break;
    }while(Number-10000>=0);

    Guess[0]=Number/1000;                    //把玩家輸入的值存進陣列Guess方便比對
    Guess[1]=Number/100-(Number/1000*10);
    Guess[2]=Number/10-(Number/100*10);
    Guess[3]=Number-(Number/10*10);
/*/
    printf("%d",Guess[0]);
    printf("%d",Guess[1]);
    printf("%d",Guess[2]);
    printf("%d\n",Guess[3]);
/*/
    A=0;
    B=0;
    for (i = 1; i<=4; i++){
            for (j = 1; j <=4;j++){
        if(Guess[i-1]==arr[j-1]){
            if(i-j==0){
            A++;
                      }
                                }
            if(Guess[i-1]==arr[j-1]){
            if(i-j!=0){
            B++;
                      }
                                    }
                                      }
                                        }
if(End==0){
    printf("A is %d\n",A);
    printf("B is %d\n",B);
}
} while(A!=4);

if(A==4){
    printf("Congratulations, You guess right!! \n");
    printf("The answer is:");
    for(i=1;i<5;i++){
        printf("%d",arr[i-1]);
    }
    printf("\n");
    printf("You want play again?\n");
    printf("If you want do it,enter 1,otherwise enter 0 to get out!\n");
    scanf("%d",&Again);
    if(Again == 1){
            goto start;
    }
    else{
        return 0;
    }
}

 /*/       for (i = 1; i <= 4; i++){
        do {
            arr[i-1] = rand() % 9;
            End = 0;
            for(j = 1; j < i; j++) {
                if (arr[i-1] == arr[j-1]) {
                    End = 1;
                    break;
                }
            }
        }while (End == 1);
        printf("%d\n", arr[i-1]);
    }
/*/


/*/

    while (GuessNum != -1){

    printf("Hello %d\n",arr[0]);
    printf("Hello %d\n",arr[1]);
    printf("Hello %d\n",arr[2]);
    printf("Hello %d\n",arr[3]);
    scanf("%d", &GuessNum);
        if(Rand1 == GuessNum) {
            printf("You are right!\n");
            A++;
        }
        else {
            printf("Oops! You are worng\n");
            B++;
        }
        printf("A:%d\n",A);
        printf("B:%d\n",B);

                     }
/*/
return 0;
}

