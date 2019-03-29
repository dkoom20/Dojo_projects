from flask import Flask, render_template, request
app = Flask(__name__)
# our index route will handle rendering our form

@app.route('/')
def index():
  return "NO NINJAS HERE"
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route

@app.route('/ninja')
def ninja():
   print "all all all all all"
   return render_template("ninja.html")

@app.route('/ninja/<color>')
def pickaninja(color):
    print color
    return render_template("pickone.html", color=color)

app.run(debug=True) # run our server