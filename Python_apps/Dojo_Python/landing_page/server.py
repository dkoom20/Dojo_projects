from flask import Flask, render_template, request
app = Flask(__name__)
# our index route will handle rendering our form

@app.route('/')
def index():
  return render_template("index.html")
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route

@app.route('/dojo/news', methods=['GET', 'POST'])
def dojonews():
  print "request form"
  print request.form
#  news = request.form['news']
  return render_template('dojo.html')

@app.route('/ninjas')
def ninjas():
  return render_template('ninjas.html')


app.run(debug=True) # run our server