from flask import Flask, render_template, redirect, session, request
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'
# our index route will handle rendering our form

@app.route('/')
def index():
    if 'count' not in session:  #initialize count to 1 for first view
        session['count'] = 1
    else:
        session['count'] += 1  #add 1 to count for subsequent views when page is reloaded
    return render_template('counter.html')

@app.route('/add2')
def add2():
    session['count'] += 2
    return render_template('counter.html')

@app.route('/reset')
def reset():
    session['count'] = 0
    return redirect('/')

app.run(debug=True)  # run our server