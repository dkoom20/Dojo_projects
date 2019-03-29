from flask import Flask, render_template, request, url_for, session, redirect
import random
import time
from time import localtime, strftime

app = Flask(__name__)
app.secret_key = 'Keytothehighway' #you need to set a secret key for security purposes
@app.route('/')
def index():
    if 'total_gold' not in session:          #if first time
        session['total_gold'] = 0
        session['found_gold'] = 0
    else:
        session['total_gold'] = session['total_gold']
    if 'this_visit' not in session:          #if first time
        session['this_visit'] = []
    else:
        session['this_visit'] = session['this_visit']            
    return render_template("money.html", gold=session['total_gold'], the_result=session['this_visit']) 
 
@app.route('/process_money', methods=['POST'])
def process_money():
    time = strftime("%a, %b %d, %I:%M %p", localtime())
    print "process the gold"
    if request.form['building'] == 'farm':
        session['found_gold'] = random.randint(10, 20) # random gold 
        session['total_gold'] += session['found_gold']
        session['this_visit'].append("Earned "+str(session['found_gold'])+" golds from the farm. "+str(time))
        print "farm", session['found_gold']
    elif request.form['building'] == 'cave':
        session['found_gold'] = random.randint(5, 10) # random gold 
        session['total_gold'] += session['found_gold']
        session['this_visit'].append("Earned "+str(session['found_gold'])+" golds from the cave. "+str(time))
        print "cave", session['found_gold']
    elif request.form['building'] == 'house':
        session['found_gold'] = random.randint(2, 5) # random gold 
        session['total_gold'] += session['found_gold']
        session['this_visit'].append("Earned "+str(session['found_gold'])+" golds from the house. "+str(time))
        print "house", session['found_gold']
    elif request.form['building'] == 'casino':
        session['found_gold'] = random.randint(-50, 50) # random gold 
        session['total_gold'] += session['found_gold']
        if session['found_gold'] > 0:
            session['this_visit'].append("Entered a casino and won "+str(session['found_gold'])+" golds. "+str(time))
        else:
            session['this_visit'].append("Entered a casino and lost...ouch!... "+str(session['found_gold'])+" golds. "+str(time))

        print "casino", session['found_gold']
    
    return redirect('/')          #restart

 
@app.route('/replay')
def replay():
    session.pop('found_gold')     #reset
    session.pop('total_gold')     #reset

    return redirect('/')          #restart

app.run(debug=True)