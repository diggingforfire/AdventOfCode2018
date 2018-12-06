package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {

	input, _ := readAllLines("input.txt")

	result := find(input, make([]int, 0), 0)

	fmt.Println(result)
}

func find(input []string, seen []int, sum int) int {

	for i := 0; i < len(input); i++ {
		val, _ := strconv.Atoi(input[i])
		sum += val

		for _, e := range seen {
			if sum == e {
				return sum
			}
		}

		seen = append(seen, sum)
	}

	return find(input, seen, sum)
}

func readAllLines(filePath string) (lines []string, err error) {
	f, err := os.Open(filePath)
	if err != nil {
		return
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	err = scanner.Err()
	return
}
