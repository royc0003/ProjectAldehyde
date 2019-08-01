package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"os"
	"strconv"
)

func Cap(str []byte) []byte {

	isCap := true
	for i := 0; i < len(str); i++ {
		if isCap {
			isCap = false
			if str[i] >= 97 && str[i] <= 122 {
				str[i] -= 32
			}
			if str[i] == ' ' {
				isCap = true
			}
		}
	}
	return str
}

type Users struct {
	Users []User `json:"users"`
}

type User struct {
	Name   string `json:"name"`
	Type   string `json:"type"`
	Age    int    `json:"Age"`
	Social Social `json:"social"`
}

type Social struct {
	Facebook string `json: "facebook"`
	Twitter  string `json: "twitter"`
}

func main() {
	jsonFile, err := os.Open("users.json")

	if err != nil {
		fmt.Println(err)
	}
	fmt.Println("Successfully Opened Json file")
	defer jsonFile.Close()

	byte, _ := ioutil.ReadAll(jsonFile)

	var users Users

	json.Unmarshal(Cap(byte), &users)

	for i := 0; i < len(users.Users); i++ {
		fmt.Println("User Type: " + users.Users[i].Type)
		fmt.Println("User Age: " + strconv.Itoa(users.Users[i].Age))
		fmt.Println("User Type: " + users.Users[i].Name)
		fmt.Println("User Type: " + users.Users[i].Social.Facebook)
	}
}
