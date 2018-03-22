package main

import (
	"fmt"
	"os"

	"github.com/valyala/fasthttp"
)

func doRequest(url string, body string) {
	req := fasthttp.AcquireRequest()
	req.SetRequestURI(url)
	req.Header.SetMethod("POST")
	req.Header.Set("Content-Type", "application/json")
	req.SetBodyString(body)

	resp := fasthttp.AcquireResponse()
	client := &fasthttp.Client{}
	client.Do(req, resp)

	bodyBytes := resp.Body()
	// println("Request Response:")
	// println(string(bodyBytes))
	fmt.Print(string(bodyBytes))
	// User-Agent: fasthttp
	// Body: p=q
}

func main() {
	uri := os.Args[1]
	postBody := os.Args[2]
	// println(uri)
	// println(postBody)

	//go run .\fasthttp-post-wrapper.go 'http://localhost:5001/api/script/run' '{ \"ScriptName\" : \"TESTE\", \"Token\": \"69558fae-7aa8-4095-801f-0df04b14d3c8\", \"ScriptParameters\" : { \"entrada\": 123 } }'

	// doRequest("http://127.0.0.1:5001/api/script/run", "{ \"ScriptName\" : \"TESTE\", \"Token\": \"69558fae-7aa8-4095-801f-0df04b14d3c8\", \"ScriptParameters\" : { \"entrada\": 123 } }")
	doRequest(uri, postBody)
}
