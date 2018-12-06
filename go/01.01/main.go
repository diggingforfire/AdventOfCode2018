package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {
	content, _ := readAllLines("input.txt")
	sum := 0

	for i := 0; i < len(content); i++ {
		val, _ := strconv.Atoi(content[i])
		sum += val
	}

	fmt.Println(sum)
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
