Basmah Arif | Module CMP6187 Mobile Game Development | Student ID:21159823

## MobileDevelopment

## Overview

This project contains Mobile Game Development project developed using Unity, Unreal Engine and Visual Studio. It will be thoroughly tested using an Android Samsung A52 device with API 31. Lightdash:Break the Beam is a single-player mobile game that combines fast-paced reflexes with strategic puzzle-solving. The player is trapped in a series of increasingly complex laser filled rooms and must navigate through the maze while avoiding deadly lasers and other obstacles. The game includes four progressively challenging levels, each with unique environments and mechanics to test the player's skill.
The game is built using Unity and C# for scripting. The project focuses on implementing dynamic obstacles, responsive controls, and level progression to keep players engaged on Mobile App.

## Description of the Game

In Lightdash:Break the Beam, player is tasked with escaping from a series of laser filled rooms. Each level presents a different challenge, ranging from dodging moving laser beams, solving mazes, to performing precision jumps in parkour-style sections. The goal is to reach the exit, all while avoiding deadly laser beams. 

**Levels:**

- Level 1 – Laser Room:
Player is introduced to the basic mechanics by navigating through a room filled with stationary lasers. The objective is simple: avoid touching the lasers and reach the exit.

- Level 2 – Maze Challenge:
This level introduces a basic maze with laser obstacles. Player must find the correct path through the maze while avoiding lasers that rotate or move along fixed paths.

- Level 3 – Parkour Escape:
Player must jump between platforms while avoiding lasers. Some platforms will collapse after a short time, adding an extra challenge to the parkour elements.

- Level 4 – Ultimate Escape:
The final level includes a mix of jumping, dodging lasers, and activating switches that open doors to the exit. Player must time their movements carefully to avoid traps and escape in time.


## Game Mechanics

- **Single-Player Experience:**
  
The game is designed as a single-player adventure where the player takes full control of navigating each level, focusing on timing, reflexes, and strategy to overcome obstacles.

- **Touch-Based Controls:**
  
1) Swipe Left/Right: Moves the player character left or right.
2) Swipe Up: Makes the player jump.
3) Swipe Down: Allows the player to crouch (useful for dodging certain obstacles).
4) Tap: Interacts with objects like switches or buttons.

- **Running and Walking:**
Player can control the speed of the movement based on swiping intensity. A short swipe makes the character walk, while a longer, faster swipe makes the character run. This adds an element of timing to avoid lasers and navigate obstacles.

- **Jumping:**
Tapping or swiping up allows the player to jump over obstacles. Some areas will require precise timing to avoid laser beams or cross collapsing platforms.

- **Laser Avoidance:**
Lasers are the primary obstacle throughout the game. They vary between static, rotating, and moving patterns, requiring precise timing to avoid. Touching a laser results in an instant loss of a life, depending on the difficulty mode.

- **Mazes and Puzzles:**
In maze level, player must navigate through a complex layout while avoiding obstacles. The layout of the maze is dynamic, with lasers blocking some paths and opening others at random intervals.

- **Parkour Mechanics:**
Parkour levels require players to jump between platforms while avoiding obstacles. Timing and precision are essential, as some platforms collapse or move.

- **Switches and Puzzles:**
Some levels include switches that players must activate to open doors or disable lasers.

- **Power-ups:**
Occasionally, power-ups spawn in difficult-to-reach areas. These can temporarily slow down obstacles, increase the player’s speed, or extend the level’s time limit, offering brief relief during particularly challenging sections.

- **Health and Timer:**
Certain levels have a time limit, requiring player to complete the level before time runs out. In advanced levels, player can take minor damage (losing a life) from non-lethal obstacles (like falling platforms), but touching lasers results in an immediate reset of the level.


## Visual and Audio Design

- Futuristic Aesthetic:
The game features colored lasers and metallic walls, giving it a clean, sci-fi look. The lasers have a glowing effect to ensure they stand out.

- Minimalistic Design:
The overall visual design is kept simple to ensure that the focus remains on the navigation challenge.

## Background/Motivation

Lightdash:Break the Beam draws inspiration from classic arcade-style reflex games and modern puzzle-platformers. The idea of navigating through deadly environments came from my love for high-tension parkour games where players must balance both quick decision-making and strategic planning. The combination of different challenges across levels: such as avoiding lasers, solving mazes, and completing parkour obstacles creates an engaging variety that keeps the gameplay fresh and exciting.
The decision to include mobile-friendly touch controls was based on the desire to create a highly accessible experience that players could enjoy on the go. With each level offering a unique type of challenge, from reflex-based dodging to puzzle-solving and platforming, Lightdash:Break the Beam aims to provide a broad range of challenges for mobile gamers.


## Technologies Used

- Visual Studio: https://https//code.visualstudio.com/ (Code Development)
- Unity: https://unity.com/ (Game Engine used for development - Stage 1 & 2)
- GitHub: (Version control and collaboration)
- C#: (Programming Languages for scripting and game mechanics)


## Tutor Feedback Reflection

**Week 3 Feedback:**

**Feedback:** Discussed the Game Idea with Dr.Kurtis and he suggested great ideas to make it better with adding monetizations/ads/In-App purchases. Also suggested to add difficulty levels to keep the players engaging.

**Action Taken:** Started Initial planning, basic level designs and laser mechanics. Along with deciding on the lasers, obstacles, player health system and timers in the game. 


**Week 7 Feedback:**

**Feedback:** The feedback was invaluable, as it helped me identify areas needing improvement, especially around touch control sensitivity and UI accessibility. Making these adjustments improved the gameplay experience and allowed me to address areas that could impact the final submission.

**Action Taken:** Addressed feedback, enhanced touch control sensitivity, refined player movement and made UI adjustments for better accessibility. Continued to implement feedback-driven improvements to prepare for the next submission.ers in the game. 


**Week 12 Feedback:**

**Feedback:** Dr.Kurtis provided detailed guidance on the progress of mobile features, emphasizing the need to refine sensor integration and explore Unity’s input system for a seamless user experience. He also suggested leveraging features like vibrations and incorporating Google Play Services to enhance gameplay and platform compatibility.

**Action Taken:** Based on the feedback, I began implementing vibration levels (high, medium, low) for different in-game events to improve player immersion. I also started integrating Unity’s Input System to streamline touch and sensor-based controls. Additionally, I explored the setup for Google Play Services to ensure the game is ready for platform-specific functionalities. Progress on these features will be demonstrated in the upcoming bootcamp session for further review.

**BootCamp Feedback:**


## Folders / Structures

Basmah_Arif_21159823

1. [bin] (contains compiled binaries)
   
2. [code] (contains source code)
   
3. [imgs] (contains projects images and visual assets)
   
4. [labs] (contains lab workshops from week to week, documenting the progress of lectures)
   
5. .gitignore (contains untracked files to ignore in Git such as Build files, logs)
    
6. [Readme] (this file contains documentation)
    
7. [video] (this file will contain gameplay and project demo videos with h264/aac however not yet implemented)

## Installation

Clone the repository to your local machine:

git clone https://github.com/basmah113/mobiledevelopment.git

Open the project in Unity.

Connect your Android device or use an emulator with API level 31.

Build and run the application on an Android device.

## Visual Studio

TODO: 

1) Download Visual Studio from the "https://visualstudio.microsoft.com/downloads/"
2) Run the installer 
3) Selected recommended workloads (C++)
4) Open Visual Studio from application folder

## Development Methodology

- I have used GitHub Projects Agile methodology to track my tasks and progress.
- Regular use of GitHub Issues for feature tracking and task assignment.

**Quality Assurance**

- I will be using code linting for consistency and bug prevention.
- CI/CD setup in GitHub to ensure smooth integration and testing.
- Regular code reviews by automated tests to validate the codebase.

## Contributing

1. Git hub repository
2. Features: `git checkout -b myrepository`
3. Commit changes: `git commit -am 'basmah113'`
4. Push to the branch: `git push origin my-repository`
5. Submit a pull request :D

**Contributors**

- Basmah Arif - Lead Developer


## Weekly Logbook

Throughout my time in studying, this weekly logbook will document the skills, methodologies, and achievements I acquire and accomplish during my Semester 1 Mobile Game Development Module. I will record this information on a week-to-week basis, offering detailed insights into the tasks I undertake. Moreover, I will highlight how these tasks contribute to expanding my expertise in my role as a Mobile Game Developer. 


## September 2024

**Week 1: Introduction of the module – W/C 23rd September 2024**

The first week started with the introduction of the Mobile Game module along with the overview of the Assessment Guide which we must submit for this module. Dr. Kurtis explained us what is required for this module and showed us past samples of students’ games for us to get an idea on our personal startup projects. He suggested us that we should be writing weekly logbooks, creating drafts/drawings of our game ideas and making a presentation. Then he guided us onto our Lab workshop which was to setup Unity for Android and IOS versions and connect it to our Mobile phones. Following on from his guidance, I decided to make separate folders for my modules of Semester 1 and started writing my logbook, organising my documents and Uploading my Lab work in GitHub to stay up to date with the progress. 

•	Reflection: I realized how important early organization is, which led me to begin structuring my work right away. Setting up the development environment was also crucial because it helped me prepare for the upcoming tasks.

•	Milestone: Created separate folders for all modules, began writing the weekly logbook, and organized my documentation. Uploaded my first lab work to GitHub to stay on track with progress.



**Week 2: Learning Prototyping & deciding Game Idea – W/C 30th September 2024**

This week, we learned about Prototyping and how Gyroscope is used in Mobile Game. Our task was to make a quick easy game utilising the sensors of a mobile phone for testing. Unfortunately, my Unity version on the PC was unable to let me test properly in my mobile as it required Android API level which kept on failing to connect to my mobile’s unity remote. I discussed this with Dr. Kurtis, and he assured me that he will look at the problem as some machines had this same issue last year as well. However, I completed the Lab work and decided to create a GitHub repository to upload my work. At first, it was a challenge to decide what I am planning to do for my Game Project for this module. I started looking up for few ideas to collect and initiated with randomly drafted my game scene. I started to decide the theme, levels, characters of the game. 

•	Reflection: I faced technical issues that slowed my progress, but it taught me the importance of troubleshooting early and managing issues with the development environment.

•	Milestone: Created my GitHub repository, completed the lab tasks, and began drafting ideas for my game project, outlining potential themes, characters, and levels.



## October 2024


**Week 3: Discussion of Game Idea – W/C 7th October 2024**

In this week, I carried out with the lab workshop which was to add some Particles on a project of weather to give it a snowy look with some snowflakes dropping down on a plane. Apart from this, I discussed my Game Idea with Dr. Kurtis on what I am planning to do. The idea is to create a 3D maze game with 2 to 3 levels with the Maze having some obstacles as Laser and the main player must escape the maze without touching the laser points. Dr. Kurtis asked me several questions related to the game and suggested ideas on adding In App Purchases, Ads and where/how to use those ads in the game. He liked the idea of the game and further suggested me to plan it ahead with requirements. Also, with this, he explained how we should document all our screenshots, designs and gave instructions to update logbooks. 

•	Reflection: Discussing the idea with Dr. Kurtis gave me the clarity I needed to refine my concept and helped me understand how in-app purchases and ads could be incorporated.

•	Milestone: Finalized the concept for a 3D maze game and began planning the implementation of in-app purchases and ads. Updated my logbook and started documenting design sketches and early concepts.



**Week 4: Stage 1 Prototype & Pitch Preparation – W/C 14th October 2024**

This week started off with initial planning to prototyping, focusing on refining game ideas and preparing for Stage 1 submission. I developed sketches for the maze, characters and obstacles to make sure that they align with the game mechanics. I also began documenting core ideas, including game mechanics, player abilities, and potential narrative elements to enhance immersion. In our Week 4 lecture, I reviewed the assessment guide with Dr. Kurtis and clarified requirements for integrating In-App Purchases (IAPs) and ads. His feedback helped me consider how these elements could enhance gameplay and monetization. I also completed the Lab workshops by implementing basic game scene in Unity. Towards the end of the week, I started preparing for the upcoming pitch by outlining the game’s core mechanics and unique features, such as mobile sensor integration. 

•	Reflection: This week helped me consolidate my ideas into a more structured plan, especially after discussing monetization strategies and working on early prototyping. The pitch preparation pushed me to focus on clearly communicating my game’s unique features.

•	Milestone: Completed sketches for the core elements of the game, started documentation for game mechanics, and began pitch preparation. Built a basic game scene in Unity and outlined core game features for the Stage 1 submission.



**Week 5: Presentation & Further Implementations – W/C 21st October 2024**

This week began with the presentation for Stage 1, where I showcased my documentation, game idea and initial prototype to Dr. Kurtis. Following the presentation, I resumed work on the game scene, focusing on building out the level design and refining player interactions. I implemented additional visual elements in the game scene to create a more engaging environment and started exploring ways to integrate laser obstacles and simple animations for the player character. 

•	Reflection: Presenting my work helped clarify the direction of my game and provided motivation to improve the game scene. Focusing on the core scene development allowed me to create a more immersive experience that aligns with my initial vision.

•	Milestone: Completed the Stage 1 presentation and implemented additional features in the game scene, including obstacle integration and player interaction improvements.



**Week 6: Worked on Mobile Features for the Game – W/C 28th October 2024**

This week, I dedicated time to integrating mobile-specific features such as touch controls and basic gyro functionalities. This included implementing swipe gestures for movement and setting up accelerometer functions to add a layer of interactivity to the game. I also tested the prototype on different mobile devices to ensure compatibility and responsiveness across screen sizes. The lab session covered mobile-specific optimization, which was helpful in fine-tuning the game for a smoother user experience.

•	Reflection: Working on mobile features highlighted the importance of testing on multiple devices early on, as this uncovered some UI scaling issues. Implementing gyro and touch controls was challenging but rewarding, as it added a more immersive experience to the game.

•	Milestone: Successfully implemented touch controls and initial gyro functions, tested compatibility across various screen sizes, and addressed minor UI issues for better user experience on mobile.



## November 2024


**Week 7: Feedback on the Progress & Continued the Game Project – W/C 04th November 2024**

In Week 7, I received feedback on the current progress, which included suggestions for refining specific features. Based on this, I adjusted the touch controls to improve their responsiveness and reviewed the UI layout for accessibility enhancements. Additionally, I worked on improving the game's core mechanics, particularly focusing on refining the player movement and integrating additional visual elements to enhance immersion. The lab sessions this week provided insights into further mobile optimizations, which I applied to improve performance.

•	Reflection: The feedback was invaluable, as it helped me identify areas needing improvement, especially around touch control sensitivity and UI accessibility. Making these adjustments improved the gameplay experience and allowed me to address areas that could impact the final submission.

•	Milestone: Addressed feedback, enhanced touch control sensitivity, refined player movement and made UI adjustments for better accessibility. Continued to implement feedback-driven improvements to prepare for the next submission.



**Week 8: Memory and Asset Optimization – W/C 11th November 2024**

In Week 8, I learned about memory and asset optimization techniques to ensure our game performs efficiently on mobile devices. Dr.Kurtis guided us through the assessment breakdown and reiterated the key requirements for our projects. I started applying memory optimization strategies, such as reducing texture sizes and managing in-game assets efficiently, to improve the performance of my game. Additionally, I reviewed the project documentation to ensure it aligns with the assessment criteria.

• Reflection: Learning about optimization helped me understand the importance of balancing performance and visual quality. Applying these techniques enhanced the game's responsiveness and ensured better compatibility with lower-end devices.

• Milestone: Implemented initial memory and asset optimization techniques and reviewed project documentation based on the assessment breakdown.



Week 9: Easing Functions, Audio and Optimization Tips – W/C 18th November 2024

This week focused on practical tips for optimizing mobile games, including easing functions, audio management and movement interpolation using Lerp. I began applying easing functions to smooth player animations and integrated basic audio features, such as background music and sound effects, for better immersion. Additionally, I continued refining the performance of the game based on optimization tips learned in class.

• Reflection: Implementing easing functions and audio added polish to the gameplay experience, making movements and transitions feel more fluid and engaging. The insights into optimization further enhanced my ability to improve performance while maintaining quality.

• Milestone: Integrated easing functions and audio into the game. Refined optimization techniques for smoother gameplay performance.



Week 10: Publishing to Google Play Store – W/C 25th November 2024

In Week 10, we focused on the process of publishing Unity games to the Google Play Store. I learned about setting the target API level to 31 or above and ensuring the game meets Google’s requirements for publishing. Additionally, I worked on implementing features from Chapters 10, 11, and 12 of our course material, including polishing the UI, refining controls and enhancing game mechanics for the final build.

• Reflection: Understanding the publishing process was essential for preparing the game for deployment. Working on these implementations helped me align the game with industry standards and improve its readiness for submission.

• Milestone: Prepared the game to meet Google Play Store requirements. Implemented features from Chapters 10, 11 and 12 into the game.



## December 2024


Week 11: Web Game Development and Final Queries – W/C 2nd December 2024

This week, we discussed web game development related to mobile games and addressed project queries with Dr.Kurtis. I finalized the UI and ensured cross-platform compatibility while continuing to refine the game mechanics. I also explored the possibility of converting the game into a web-based version, focusing on making it lightweight and responsive.

• Reflection: Discussing queries with Dr.Kurtis provided clarity on final adjustments needed for the project. Exploring web game development expanded my understanding of cross-platform game deployment and gave me insights into future possibilities for the project.

• Milestone: Finalized the game’s UI and continued polishing the mechanics. Addressed project queries and ensured the game is ready for final feedback.



Week 12: Final Instructions and Project Review – W/C 9th December 2024

In the final week, we received detailed instructions about the project submission and reviewed our games with Dr. Kurtis. I applied the last round of optimizations and ensured all features were functioning as intended. Reading materials on the Moodle page provided additional insights into polishing the game for submission. 

• Reflection: The final review and instructions were crucial in identifying and addressing minor issues in the game. 

• Milestone: Implemented further optimizations and ensured cross-device compatibility.



Week 13: BootCamp Session & Project Implementation for Submission – W/C 16th December 2024

Pending



Week 14: – W/C 23rd December 2024

Pending



Week 15: – W/C 30th December 2024

Pending



## References





