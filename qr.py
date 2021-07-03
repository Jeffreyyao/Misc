import qrcode
q = qrcode.QRCode()
d = input("type data: ")
q.add_data(d)
q.make()
m = q.get_matrix()
for i in range(len(m)):
 l = ''
 for j in range(len(m)):
  if m[i][j]:
   l+='  '
  else:
   l+="\u2588\u2588"
 print(l)

