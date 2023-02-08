let A = 0, B = 0, count = 0;
let answerArr = new Array(4), guessArr = new Array(4);
var check = document.getElementById("btn");
var reset = document.getElementById("btn3");
var input = document.getElementById("guess");
var result = document.getElementById("result");
var record = document.getElementById("record");
randomNum();  // 初始的答案值

check.addEventListener("click", function () {    // check的按鈕事件監聽
    getAnswer();
    result.innerHTML = checkAnswer();
    record.innerHTML += forRecord();
    count++;

    if (A == 4) {
        alert("恭喜你猜對了！");
        gameStop();
    }

    if (count == 10) {
        alert("一輪只能猜十次喔！");
        gameStop();
    }

})

reset.addEventListener("click", function () {   // agian的按鈕事件監聽   先重置遊戲再生成一組新數字
    resetGame();
    randomNum();
    count = 1;
    input.value = "";
})

function checkAnswer() {             //遍歷陣列後回傳A跟B的值
    A = 0; B = 0;
    for (let i = 0; i <= 3; i++) {
        for (let j = 0; j <= 3; j++) {
            if (answerArr[i] === guessArr[j] && i === j) {
                A++;
            }
            else if (answerArr[i] === guessArr[j] && i !== j) {
                B++;
            }
        }
    }
    return A + "A" + B + 'B';
}

function randomNum() {                      // 生成亂數
    for (let i = 0; i <= 3; i++) {
        answerArr[i] = Math.floor(Math.random() * 9);
        for (let j = 0; j < i; j++) {
            if (answerArr[i] === answerArr[j]) {   // 如果相等重跑一次
                randomNum();
                break;
            }
        }
    }
    return answerArr;
}

function getAnswer() {          //把玩家輸入的值存進陣列方便比對
    var playInput = input.value;
    guessArr[0] = parseInt(playInput / 1000);
    guessArr[1] = parseInt(playInput / 100 - (guessArr[0] * 10));
    guessArr[2] = parseInt(playInput / 10) - parseInt(playInput / 100) * 10
    guessArr[3] = playInput - (parseInt(playInput / 10) * 10);
    return guessArr;
}

function resetGame() {     // 重置遊戲 把按鈕設成disabled
    randomNum();
    record.innerHTML = "Record：<br>";
    check.innerHTML = "Check!";
    check.disabled = false;
}

function forRecord() {      //單純是美觀
    return count + "." + guessArr[0] + guessArr[1].toString() + guessArr[2].toString() + guessArr[3].toString() + "&nbsp;" + A + "A" + B + "B" + "<br>";
}

function gameStop() {   //
    check.disabled = true;
    check.innerHTML = "STOP!";
    input.value = "again!";
}
