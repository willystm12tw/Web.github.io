let test = 0, A = 0, B = 0, count = 1;
let answerArr = new Array(4);
let guessArr = new Array(4);
var check = document.getElementById("btn");
var reset = document.getElementById("btn3");
var input = document.getElementById("guess");
var result = document.getElementById("result");
var answer = document.getElementById("answer");
var record = document.getElementById("record");

function checkAnswer() {
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

randomNum();
answer.innerHTML = answerArr[0] + answerArr[1].toString() + answerArr[2].toString() + answerArr[3].toString();

check.addEventListener("click", function () {
    getAnswer();
    result.innerHTML = checkAnswer();
    record.innerHTML += count + "." + guessArr[0] + guessArr[1].toString() + guessArr[2].toString() + guessArr[3].toString() + "&nbsp;" + A + "A" + B + "B" + "<br>";
    count++;
    result.innerHTML = checkAnswer();

    if (A == 4) {
        alert("恭喜你猜對了！");
        check.disabled = true;
        check.innerHTML = "STOP!";
        input.value = "again!";
    }

    if (count == 11) {
        alert("一輪只能猜十次喔！");
        check.disabled = true;
        check.innerHTML = "STOP!";
        input.value = "again!";
    }

})

reset.addEventListener("click", function () {
    resetGame();
    randomNum();
    answer.innerHTML = answerArr[0] + answerArr[1].toString() + answerArr[2].toString() + answerArr[3].toString();
    count = 1;
    input.value = "";
})

function randomNum() {
    for (let i = 0; i <= 3; i++) {
        answerArr[i] = Math.floor(Math.random() * 9);
        for (let j = 0; j < i; j++) {
            if (answerArr[i] === answerArr[j]) {
                randomNum();
                break;
            }
        }
    }
    return answerArr;
}

function getAnswer() {
    var playInput = input.value;
    guessArr[0] = parseInt(playInput / 1000);                    //把玩家輸入的值存進陣列Guess方便比對
    guessArr[1] = parseInt(playInput / 100 - (guessArr[0] * 10));
    guessArr[2] = parseInt(playInput / 10) - parseInt(playInput / 100) * 10
    guessArr[3] = playInput - (parseInt(playInput / 10) * 10);
    return guessArr;
}

function resetGame() {
    randomNum();
    record.innerHTML = "Record：<br>";
    check.innerHTML = "Check!";
    check.disabled = false;
}