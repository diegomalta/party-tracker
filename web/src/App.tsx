import React from 'react';
import './App.css';
import RsvpForm from './views/RsvpForm/RsvpForm';

function App() {
  return (
    <div className='container mx-auto'>
      <RsvpForm />
      <p className='text-center text-gray-500 text-xs'>Lina's Party all Right reserved.</p>
    </div>
  );
}

export default App;
