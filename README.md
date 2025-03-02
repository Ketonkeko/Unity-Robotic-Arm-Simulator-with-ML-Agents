![image](https://github.com/user-attachments/assets/cc7fb5d6-83e5-42cb-8f88-c1c1da20a9ca)

---

# 🤖 Robotic Arm Simulation with Q-Learning in Unity

This project is a **robotic arm simulation** built in **Unity**, utilizing **ML-Agents** for **reinforcement learning** with **Q-learning**. The robotic arm learns to perform tasks by interacting with its environment and improving its performance through rewards.

## 🚀 Features

- 🏗 **Robotic Arm Simulation** – A fully functional robotic arm modeled in Unity.
- 🧠 **Q-Learning Implementation** – Uses reinforcement learning to optimize movements.
- 🎛 **ML-Agents Integration** – Built with **ML-Agents 2.0.1** for training AI models.
- 📊 **Real-Time Learning Visualization** – Observe training progress within Unity.
- 🔧 **Customizable Reward System** – Modify rewards to fine-tune training behavior.

## 🔧 Requirements
![Ekran görüntüsü 2024-05-11 230955](https://github.com/user-attachments/assets/0d54339e-a407-461f-9a5b-d8554554f055)
![Ekran görüntüsü 2024-05-11 181659](https://github.com/user-attachments/assets/eca3bdd8-40a5-4412-a653-f0e0e440cab5)

Ensure the following dependencies are installed before running the project:

- **.NET SDK 6**  
- **Visual Studio C++ 14.0**  
- **Visual Studio Build Tools**  
- **.NET Framework 4.7.1**  
- **Python 3.10**  
- **Unity Editor 2022.3.7f1**  
- **ML-Agents 2.0.1 (Unity Package)**  
- **PIP 24.0**  
- **PyTorch 1.12**  
- **ML-Agents 10**  
- **NumPy 1.23**  

## 🧠 What is Reinforcement Learning?

Reinforcement learning (RL) is a machine learning method where an **agent** learns through interactions with an **environment**. The agent receives **rewards** for good actions and **penalties** for poor choices, allowing it to improve its behavior over time.

### Key RL Concepts:

- **Agent** – The robotic arm making decisions.  
- **Environment** – The simulated world where the robot operates.  
- **Actions** – Movements or commands the agent can perform.  
- **Reward** – Positive or negative feedback guiding the agent’s learning.  
- **Policy** – The strategy dictating the agent’s decision-making.  

Reinforcement learning is widely used in **robotics**, **game AI**, and **automation**.

## 🛠 Installation Guide

Follow these steps to set up and run the project:

1. **Navigate to the Unity project directory**:
   ```sh
   cd path/to/your/unity/project
   ```
2. **Create a Python virtual environment**:
   ```sh
   py -m venv venv
   ```
3. **Activate the virtual environment**:
   - On Windows:
     ```sh
     venv\Scripts\activate
     ```
   - On macOS/Linux:
     ```sh
     source venv/bin/activate
     ```
4. **Upgrade pip**:
   ```sh
   python -m pip install --upgrade pip
   ```
5. **Install PyTorch**:
   ```sh
   pip install torch==1.12.0 -f https://download.pytorch.org/whl/torch_stable.html
   ```
6. **Install ML-Agents and NumPy**:
   ```sh
   pip install mlagents numpy==1.23
   ```
7. **Verify ML-Agents installation**:
   ```sh
   mlagents-learn --help
   ```
8. **Install ML-Agents package in Unity**:  
   - Open Unity  
   - Use the **Unity Asset Manager** to install **ML-Agents 2.0.1**  

9. **Install Protobuf (if required)**:
   ```sh
   pip install protobuf==3.20
   ```

**tensorboard 2.16.2 usage**

In a separate terminal;

tensorboard --logdir results

we type localhost:6006 in the browser we will use and connect to the local host

![image](https://github.com/user-attachments/assets/60b3334d-a750-42e2-a575-5a864f670542)

## 📜 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Feel free to submit **pull requests** or open **issues**.
