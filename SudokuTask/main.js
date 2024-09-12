
let inputValue = [
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
]

console.log(validSolution(inputValue))

function validSolution(matrix){
    let len = 9

    //Checking if matrix is not 9x9
    if(matrix.length != 9){
        throw new Error("Bad matrix")
    }
    for(let i = 0; i<9; i++){
        if(matrix[i].length != 9){
            throw new Error("Bad matrix")
        }
    }

    let cols = Array.from({ length: len }, () => new Set());
    let rows = Array.from({ length: len }, () => new Set());
    let blocks = Array.from({ length: len }, () => new Set());

    //Checking rows and columns
    for(let i = 0; i < 9; i++){
        for(let j = 0; j < 9; j++){
            cols[i].add(matrix[i][j])
            rows[i].add(matrix[j][i])

            if(matrix[i][j] == 0 || matrix[j][i] == 0){
                return false;
            }
        }
    }

    //Checking blocks
    for(let i = 0; i < 9; i+=3){
        for(let j = 0; j < 9; j+=3){
            for (let x = 0; x < 3; x++) {
                for (let y = 0; y < 3; y++) {
                    blocks[Math.floor(i / 3) * 3 + Math.floor(j / 3)].add(matrix[i+x][j+y]);
                }
            }
        }
    }

    return checkValid()

    function checkValid(){
        for(let i = 0; i<9; i++){
            if(cols[i].size != 9 || rows[i].size != 9 || blocks[i].size != 9)
                return false;
        }
        return true;
    }
}