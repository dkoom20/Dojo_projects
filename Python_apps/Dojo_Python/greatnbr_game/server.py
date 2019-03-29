from flask import Flask, render_template, request, url_for, session, redirect
import random
app = Flask(__name__)
app.secret_key = 'Keytothehighway' #you need to set a secret key for security purposes
@app.route('/')
def index():
    session['random_nbr'] = random.randint(1, 100) # random number 
    return render_template("index.html", random=session['random_nbr']) 
 
@app.route('/guess', methods=['POST'])
def guess():
    session['guess'] = int(request.form['guess']) #convert string to integer
    return render_template("game.html", guess=session['guess'], random=session['random_nbr'], comp_wins=session['comp_wins'], user_wins=session['user_wins']) #pass the guess, the number, and the win/loss stats

@app.route('/correct', methods=['POST'])
def correct():
    session['user_wins'] += 1           
    session.pop('guess')          #reset
    session.pop('random_nbr')     #reset 
    return redirect('/')          #restart

app.run(debug=True)