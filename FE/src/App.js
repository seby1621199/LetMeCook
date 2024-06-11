import React, { useState } from 'react';
import './App.css';
import Dishes from './Dishes';

function App() {
  const [ingredient, setIngredient] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    const newIngredient = event.target.elements.ingredient.value;
    setIngredient(newIngredient);
  };

  return (
    <>
      <div className='form' >
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            name="ingredient"
            placeholder="Enter ingredient"
          />
          <input type='submit'></input>
        </form>
      </div>
      <div className="main-container">
        <Dishes ingredient={ingredient} />
      </div>
    </>
  );
}

export default App;
