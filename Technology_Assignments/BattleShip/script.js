const player1Board = document.getElementById('player1Board');
const player2Board = document.getElementById('player2Board');
const startButton = document.getElementById('startButton');
const player1Ctx = player1Board.getContext('2d');
const player2Ctx = player2Board.getContext('2d');
const gridSize = 10;
const cellSize = player1Board.width / gridSize;

let isGameStarted = false;
let currentPlayer = 1;

const player1Ships = [];
const player2Ships = [];

// Add event listeners for the ships
const ships = document.querySelectorAll('.ship');
ships.forEach(ship => {
    ship.addEventListener('dragstart', dragStart);
});

function dragStart(event) {
    event.dataTransfer.setData('text/plain', event.target.id);
}

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
    if (currentPlayer === 2) {
        aiTurn();
    }
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

function handleDrop(event, ctx, ships) {
    event.preventDefault();
    const id = event.dataTransfer.getData('text');
    const ship = document.getElementById(id);

    const rect = event.target.getBoundingClientRect();
    const x = event.clientX - rect.left;
    const y = event.clientY - rect.top;
    const row = Math.floor(y / cellSize);
    const col = Math.floor(x / cellSize);

    const size = parseInt(ship.dataset.size, 10);
    const positions = [];

    for (let i = 0; i < size; i++) {
        positions.push([row + i, col]);
    }

    if (currentPlayer === 1) {
        player1Ships.push({ positions, hits: [] });
    } else {
        player2Ships.push({ positions, hits: [] });
    }

    drawShip(ctx, row, col, size);
    ship.draggable = false;  // Disable dragging after placement
}

function drawShip(ctx, row, col, size) {
    ctx.fillStyle = '#8b0000';
    for (let i = 0; i < size; i++) {
        ctx.fillRect(col * cellSize, (row + i) * cellSize, cellSize, cellSize);
    }
}

function handleDragOver(event) {
    event.preventDefault();
}

function aiPlaceShips() {
    for (let size of [5, 4, 3, 3, 2]) {
        let placed = false;
        while (!placed) {
            const isVertical = Math.random() >= 0.5;
            const row = Math.floor(Math.random() * (gridSize - (isVertical ? size : 0)));
            const col = Math.floor(Math.random() * (gridSize - (!isVertical ? size : 0)));
            const positions = [];
            for (let i = 0; i < size; i++) {
                positions.push(isVertical ? [row + i, col] : [row, col + i]);
            }
            if (isValidPlacement(player2Ships, positions)) {
                player2Ships.push({ positions, hits: [] });
                drawShip(player2Ctx, row, col, size, isVertical);
                placed = true;
            }
        }
    }
}

function isValidPlacement(ships, positions) {
    for (let pos of positions) {
        for (let ship of ships) {
            for (let shipPos of ship.positions) {
                if (shipPos[0] === pos[0] && shipPos[1] === pos[1]) {
                    return false;
                }
            }
        }
    }
    return true;
}

function drawShip(ctx, row, col, size, isVertical = true) {
    ctx.fillStyle = '#8b0000';
    for (let i = 0; i < size; i++) {
        ctx.fillRect((isVertical ? col : col + i) * cellSize, (isVertical ? row + i : row) * cellSize, cellSize, cellSize);
    }
}

function aiTurn() {
    let row, col;
    do {
        row = Math.floor(Math.random() * gridSize);
        col = Math.floor(Math.random() * gridSize);
    } while (checkHit(player1Ships, row, col));
    
    if (checkHit(player1Ships, row, col)) {
        markCell(player1Ctx, row, col, 'red');
        console.log("AI hit!");
    } else {
        markCell(player1Ctx, row, col, 'blue');
        console.log("AI miss!");
    }
    switchPlayer();
}

player1Board.addEventListener('click', (event) => {
    if (currentPlayer === 2) handleCellClick(event, player1Ctx, player1Ships);
});

player2Board.addEventListener('click', (event) => {
    if (currentPlayer === 1) handleCellClick(event, player2Ctx, player2Ships);
});

player1Board.addEventListener('drop', (event) => handleDrop(event, player1Ctx, player1Ships));
player1Board.addEventListener('dragover', handleDragOver);

player2Board.addEventListener('drop', (event) => handleDrop(event, player2Ctx, player2Ships));
player2Board.addEventListener('dragover', handleDragOver);

startButton.addEventListener('click', () => {
    isGameStarted = true;
    aiPlaceShips();
    console.log('Game started');
});

drawGrid(player1Ctx);
drawGrid(player2Ctx);
