import React from "react";

interface WelcomeMessageProps {
    guestName: string
}


const WelcomeMessage = ({ guestName }: WelcomeMessageProps) => {
    return (<div className="prose text-center py-8">
        <h2>{guestName}, You're invited to Linas's party! &#127881;</h2>
        <h3>Linas is turning 8, please join us for a great celebration! &#127874;
        </h3>
    </div>)
}

export default WelcomeMessage;