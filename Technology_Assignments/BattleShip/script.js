const player1Board = document.getElementById('player1Board');
const player2Board = document.getElementById('player2Board');
const startButton = document.getElementById('startButton');
const player1Ctx = player1Board.getContext('2d');
const player2Ctx = player2Board.getContext('2d');
const gridSize = 10;
const cellSize = player1Board.width / gridSize;

let isGameStarted = false;
let currentPlayer = 1;

const player1Ships = [
    { positions: [[1, 1], [1, 2], [1, 3]], hits: [] },
    { positions: [[4, 4], [5, 4], [6, 4]], hits: [] }
];

const player2Ships = [
    { positions: [[3, 1], [3, 2], [3, 3]], hits: [] },
    { positions: [[6, 6], [6, 7], [6, 8]], hits: [] }
];

function drawGrid(ctx) {
    ctx.strokeStyle = '#000';
    for (let i = 0; i <= gridSize; i++) {
        ctx.beginPath();
        ctx.moveTo(i * cellSize, 0);
        ctx.lineTo(i * cellSize, player1Board.height);
        ctx.moveTo(0, i * cellSize);
        ctx.lineTo(player1Board.width, i * cellSize);
        ctx.stroke();
    }
}

function handleCellClick(event, ctx, ships) {
    if (!isGameStarted) {
        console.log("Game not started yet!");
        return;
    }
    
    const rect = event.target.getBoundingClientRect();
    const x = event.clientX - rect.left;
    const y = event.clientY - rect.top;
    const row = Math.floor(y / cellSize);
    const col = Math.floor(x / cellSize);
    console.log(`Clicked on cell: (${row}, ${col})`);

    if (checkHit(ships, row, col)) {
        markCell(ctx, row, col, 'red');
        console.log("Hit!");
    } else {
        markCell(ctx, row, col, 'blue');
        console.log("Miss!");
    }
    
    switchPlayer();
}

function checkHit(ships, row, col) {
    for (let ship of ships) {
        for (let pos of ship.positions) {
            if (pos[0] === row && pos[1] === col) {
                ship.hits.push([row, col]);
                return true;
            }
        }
    }
    return false;
}

function markCell(ctx, row, col, color) {
    ctx.fillStyle = color;
    ctx.fillRect(col * cellSize, row * cellSize, cellSize, cellSize);
}

function switchPlayer() {
    currentPlayer = currentPlayer === 1 ? 2 : 1;
    console.log(`Player ${currentPlayer}'s turn.`);
}

player1Board.addEventListener('click', (event) => {
    if (currentPlayer === 2) handleCellClick(event, player1Ctx, player1Ships);
});
player2Board.addEventListener('click', (event) => {
    if (currentPlayer === 1) handleCellClick(event, player2Ctx, player2Ships);
});

startButton.addEventListener('click', () => {
    isGameStarted = true;
    console.log('Game started');
});

drawGrid(player1Ctx);
drawGrid(player2Ctx);
