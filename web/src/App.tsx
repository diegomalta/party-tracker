import React from 'react';
import './App.css';
import RsvpForm from './views/RsvpForm/RsvpForm';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {

  const Rsvp = <div className='container mx-auto'>
    <RsvpForm />
    {/* <p className='text-center text-gray-500 text-xs'>Lina's Party all Right reserved.</p> */}
  </div>;

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/:guestId' element={Rsvp} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
