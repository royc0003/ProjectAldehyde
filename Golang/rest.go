package main

import (
	"bytes"
	"fmt"
	"log"
	"net/http"
)

func Cap(str []byte) []byte {

	isCap := true
	for i := 0; i < len(str); i++ {
		if isCap {
			isCap = false
			if str[i] >= 97 && str[i] <= 122 {
				str[i] -= 32
			}

		}
		if str[i] == ' ' {
			isCap = true
		}
	}
	return str
}

func indexhandler(w http.ResponseWriter, r *http.Request) {
	switch r.Method {
	case "POST":
		buffer := new(bytes.Buffer)
		buffer.ReadFrom(r.Body)
		fmt.Fprint(w, string(Cap([]byte(buffer.String()))))
	}
}

func main() {
	// LAmbda needed here
	http.HandleFunc("/", indexhandler)
	log.Fatal(http.ListenAndServe(":3001", nil))
}
