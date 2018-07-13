# 2D-Experiments

Developing good habits by conducting
2D Experiments in Unity

# Some Observations

# Movement
Object oriented approach by separating vertical and horizontal motion. This makes it easier to add additional functionality and abilities.

# Attack
Generation and augmenting lifetime of projectiles allows for a simple shooting solution.

Alternatives are:
- Wait until bullets leave screen and keep count of maximum
- Set fixed intervals in between projectiles

# Dialogue
Display text using dictionary to represent characters (keys) and text (value). Printing individual characters and manipulating the text update thread allows for more natural looking speech.
