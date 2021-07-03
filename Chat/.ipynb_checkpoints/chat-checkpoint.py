from http.server import HTTPServer, BaseHTTPRequestHandler

class SimpleHTTPRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        if self.path == '/command:%20clear':
            f = open('chat.txt','w')
            f.write('HTTP chat server\nAuthor: Zhixing Yao\n\n')
            f.close()
        elif self.path != '/':
            message = self.path[1:len(self.path)].replace('%20',' ')
            f = open('chat.txt','a')
            f.write(message+'\n')
            f.close()
        self.send_response(200)
        self.end_headers()
        f = open('chat.txt')
        text = f.read()
        f.close()
        self.wfile.write(bytes(text,'utf-8'))

httpd = HTTPServer(('localhost', 80), SimpleHTTPRequestHandler)
httpd.serve_forever()
